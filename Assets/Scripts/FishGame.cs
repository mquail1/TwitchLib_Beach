using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

// Script to control the fishing minigame

public class FishGame : MonoBehaviour
{
    // 3D Text GameObject references
    [Header("3D Text References")]
    [SerializeField] private GameObject startGameText;
    [SerializeField] private GameObject waitingText;
    [SerializeField] private GameObject exclamationText;
    [SerializeField] private GameObject gotAwayText;
    // [SerializeField] private TwitchPubSub twitchPubSub;

    // UI Object references
    [Header("UI Object References")]
    [SerializeField] private GameObject UICanvas; // Minigame canvas
    [SerializeField] private GameObject catchBar; // center fish in bar
    [SerializeField] private Slider progressBar; // catch success bar (UI Slider)
    [SerializeField] private TextMeshProUGUI catchTimer; // catchTimer UI label
    [SerializeField] private GameObject winningFishDisplay; // winning fish GameObject container
    private Rigidbody catchBarRB; // Rigidbody for the catchBar (reference is obtained in Start())


    // GameObject references from Inspector
    [Header("GameObject References")]
    [SerializeField] private GameObject winManager; // winManager controlling winning screen
    [SerializeField] private GameObject fishCam; // minigame general view camera
    [SerializeField] private GameObject winCam; // minigame winning view camera 
    [SerializeField] private GameObject fishFromArray; // reference to random fish from array
    [SerializeField] private FishRandomMovement fishFromArrayMvt; // reference to fish's movement script
    [SerializeField] private List<GameObject> fishList = new List<GameObject>(); // Dynamic; can adjust size in Inspector

    // Minigame bools (viewable in Inspector for debugging)
    [Header("MiniGame Conditions")]
    public bool rewardRedeemed = false; // must be public or can't access in PubSub (has issues with get / set)
    [SerializeField] private bool inBounds = false; // in boundaries of minigame trigger
    [SerializeField] private bool exclamationSpawned = false; // ! is currently active
    [SerializeField] private bool reelInBool = false; // reel in conditions met

    [Header("Settings")]
    [SerializeField] private float pushForce; // amt of force to push catchbar's rigidbody
    [SerializeField] private int minimumWaitTime; // minimum time to wait between "..." and "!"
    [SerializeField] private int maximumWaitTime; // maximum time to wait between "..." and "!"

    // Start() initializes with game start
    void Start()
    {
        // grab a reference to catchBar's rigidbody
        catchBarRB = catchBar.GetComponent<Rigidbody>();
    }
    
    // when entering collider zone, set conditions to begin game
    void OnTriggerEnter(Collider other)
    {   
        // check if Player was the one to trip the collider
        if (other.gameObject.tag == "Player")
        {
            // "Start Game" text appears when in Trigger zone only
            startGameText.SetActive(true);

            // set "inBounds" to true
            inBounds = true;
        }
    }

    // on when exiting collider zone, turn off conditions to begin game
    void OnTriggerExit(Collider other)
    {
        // check if Player was the one to trip the collider
        if (other.gameObject.tag == "Player")
        {
            // "Start Game" text disappear on Trigger exit
            startGameText.SetActive(false);

            // set "inBounds" to false
            inBounds = false;
        }
    }

    // Update runs every frame
    void Update()
    {
        // Start Game with F key pressed & bool conditions met
        if (Keyboard.current.fKey.wasPressedThisFrame && rewardRedeemed && inBounds)
        {
            // turn on and transition FishCam
            fishCam.SetActive(true);

            // begin fishing minigame co-routine
            StartCoroutine(waitingRoutine());
        }

        // f key pressed while ! prompt is active
        if (Keyboard.current.fKey.wasPressedThisFrame && rewardRedeemed && inBounds && exclamationSpawned)
        {
            // Debug
            Debug.Log("F pressed successfully in Hooked event -> transitioning to Reel event");

            // exclamationText set to false
            exclamationText.SetActive(false);

            // break out of all other coroutines 
            StopAllCoroutines();
            // begin reeling in coroutine
            StartCoroutine(reelIn());
        }

        // apply rigidbody forces to catchBarRB when space key is pressed & in reelIn mode
        if (Keyboard.current.spaceKey.wasPressedThisFrame && reelInBool)
        {
            // Apply forces to catchBar when space is pressed down
            catchBarRB.AddForce(Vector3.up * pushForce, ForceMode.VelocityChange); // VelocityChange physics mode
        }

        // if we have a fish reference & we're reeling in
        if (fishFromArrayMvt != null && reelInBool)
        {
            // set progressBar's slider value to the fish's inBoxCounter
            progressBar.value = fishFromArrayMvt.inBoxCounter;
            // set catchTimer's label text to the fish's internal catchTimer
            catchTimer.text = fishFromArrayMvt.catchTimer.ToString();
        }

        // if we fill the progressBar to its max value (i.e. we win)
        if (progressBar.value == progressBar.maxValue)
        {
            Debug.Log("winGame started in Update()");
            progressBar.value = 0;
            StopAllCoroutines();
            // start the winGame coroutine
            StartCoroutine(winGame());
        }

        // if we run out of time (i.e. we lose)
        if(fishFromArrayMvt != null && fishFromArrayMvt.catchTimer == 0)
        {
            // Stop all other coroutines
            StopAllCoroutines();
            // start the failedGame coroutine
            StartCoroutine(failedGame());
        }
    }

    // Coroutine playing while waiting for "!" to spawn
    private IEnumerator waitingRoutine()
    {
        // turn off start game text
        startGameText.SetActive(false);

        // introduce buffer time b/w switching states and texts
        yield return new WaitForSeconds(1);
        
        // set waiting text "..." to true
        waitingText.SetActive(true);

        // generate a random number b/w values specified in Inspector
        int waitTime = Random.Range(minimumWaitTime, maximumWaitTime);
        
        // Wait the range specified to hook fish
        yield return new WaitForSeconds((int)waitTime);

        // start the ! coroutine
        StartCoroutine(fishHookRoutine());

        // Debug.Log("End of waitingRoutine reached.");
    }

    private IEnumerator fishHookRoutine()
    {
        // set waiting 3D text to false
        waitingText.SetActive(false);
        // set the ! 3D text to true
        exclamationText.SetActive(true);
        // set ! active to true
        exclamationSpawned = true;

        // wait for one second
        yield return new WaitForSeconds(1);

        // game checks if we've hooked the fish in Update()

        // else:
        // ----Prompt Was Missed----
        exclamationText.SetActive(false);
        // transition to failedPrompt() coroutine
        yield return StartCoroutine(failedPrompt());

    }

    // failed to press f in time with "!" prompt enabled: fish gets away
    private IEnumerator failedPrompt()
    {
        // Turn off ! text
        exclamationText.SetActive(false);
        
        // Turn on "It Got Away..." text
        gotAwayText.SetActive(true);

        // Turn off reward & ! spawn bools
        rewardRedeemed = false;
        exclamationSpawned = false;

        // Wait for 3 seconds
        yield return new WaitForSeconds(3);
        
        // Turn off text
        gotAwayText.SetActive(false);
        // Turn off fishCam
        fishCam.SetActive(false);

        Debug.Log("End of failedPrompt coroutine reached");

        // Break out of all coroutines
        StopAllCoroutines();
        // Exit minigame
        yield break;
    }

    private IEnumerator reelIn()
    {
        // set reelInBool to true (to perform further checks in Update() )
        reelInBool = true;

        // enable Minigame canvas UI elements
        UICanvas.SetActive(true);
        
        // retrieve random fish object from array
        fishFromArray = getRandomFish();

        // check that we retrieved a fish properly from the array
        if (fishFromArray == null)
        {
            Debug.Log("Error retreiving fish from array");
        }

        // Reference the script attached to that fish, store in variable
        fishFromArrayMvt = fishFromArray.GetComponent<FishRandomMovement>();

        // check that we got the script reference
        if (fishFromArrayMvt == null)
        {
            Debug.Log("Error retreiving FishRandomMovement script from GameObject");
        }

        // Set fish to active status
        fishFromArray.SetActive(true);

        Debug.Log("end of ReelIn coroutine reached");
        yield break;
    }

    // Failed to catch the fish while reeling in (timer ran out)
    private IEnumerator failedGame()
    {
        // Turn on "It Got Away..." text
        gotAwayText.SetActive(true);

        // Reset internals and fish references to null
        resetFish();

        // set all bools to false
        resetAllBools();
        
        // turn off UI Canvas
        UICanvas.SetActive(false);

        Debug.Log("You lost oh no");

        // Wait for 3 seconds 
        yield return new WaitForSeconds(3);
        
        // Turn off text
        gotAwayText.SetActive(false);
        // Turn off fishCam
        fishCam.SetActive(false);

        Debug.Log("End of failedPrompt() reached");

        // Break out of all coroutines
        StopAllCoroutines();
        // Exit minigame
        yield break;
    }

    private IEnumerator winGame()
    {   
        Debug.Log("winGame entered");
        Debug.Log(fishFromArray.name);

        // turn off UI Canvas
        UICanvas.SetActive(false);

        // turn off minigame camera
        fishCam.SetActive(false);

        // Swap to win camera
        winCam.SetActive(true);

        winningFishDisplay.SetActive(true);

        // First, check the name of the winning fish we caught
        if (fishFromArray.name == "Fish_Grunion 1")
        {
            // enable object with same name in Winning Fish Display
            winningFishDisplay.transform.GetChild(4).gameObject.SetActive(true); // get the child @ position 4
        }

        else if (fishFromArray.name == "Fish_Angelfish")
        {
            // enable object with same name in Winning Fish Display
            winningFishDisplay.transform.GetChild(2).gameObject.SetActive(true); // child @ position 2
        }

        else if (fishFromArray.name == "Fish_Anglerfish")
        {
            // enable object with same name in Winning Fish Display
            winningFishDisplay.transform.GetChild(3).gameObject.SetActive(true); // child @ position 1
        }

        else // edge case
        {
            Debug.Log("There is a null reference or incorrect value for the winning fish object.");
        }
        // Reset internals, then set references to null
        resetFish();

        // set all bools to false
        resetAllBools();

        // set win manager to active
        winManager.SetActive(true);

        // Break out of all coroutines
        StopAllCoroutines();
        // Exit minigame
        Debug.Log("winGame reached the end of coroutine");
        yield break;
    }

    // returns a random fish from the array
    private GameObject getRandomFish()
    {
        return fishList[Random.Range(0, fishList.Count)];
    }

    // reset all bools to false
    private void resetAllBools()
    {
        rewardRedeemed = false;
        reelInBool = false;
        exclamationSpawned = false;
    }

    // reset all fish internals and references
    private void resetFish()
    {
        fishFromArrayMvt.resetTimer();
        fishFromArray = null;
        fishFromArrayMvt = null;
    }
}