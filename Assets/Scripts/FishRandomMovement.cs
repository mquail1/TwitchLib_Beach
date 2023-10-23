using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Have fish move randomly on Y axis ONLY within ranges specified
// Also randomizes wait times between Enum and movement speed (.1f - 1f)

public class FishRandomMovement : MonoBehaviour
{
    // GameObject references from Inspector
    [Header("GameObject References")]
    public GameObject movingFish; // reference to fish object we will control in the script
    
    // Other Settings
    [Header("Settings")]
    [SerializeField] private float minimumWaitTime; // minimum time to wait b/w movements
    [SerializeField] private float maximumWaitTime; // maximum time to wait b/w movements
    [SerializeField] private int minimumYValue; // minimum height value fish will travel to
    [SerializeField] private int maximumYValue; // maximum height value fish will travel to
    [SerializeField] private float minimumMoveSpeed; // minimum movement speed
    [SerializeField] private float maximumMoveSpeed; // maximum movement speed

    // Private variables
    private Transform fishTransform; // reference container for fish's transform
    private Vector3 startVector3; // reference to the fish's starting Vector3 position
    private Vector3 debugVector3; // a debug Vector3 used for testing
    private Vector3 randomPosition; // a Vector3 whos Y value is randomized
    private bool targetReached; // whether the fish has reached the target
    private bool startCounter = false; // whether or not we start the counter

    // External Variables
    [HideInInspector]
    public float inBoxCounter = 0; // must be public to be accessible in FishGame.cs via Inspector
    [HideInInspector]
    public float catchTimer = 1500; // the overall catch timer: initialize based on type? randomize?


    void Start()
    {
        // Reference fish object's transform
        fishTransform = movingFish.gameObject.GetComponent<Transform>();
        // set the fish's current position as its starting position
        startVector3 = fishTransform.position;
        // set the debug vector3 to x = -10, y = 10, z = -4 (around the center of the bar)
        debugVector3 = new Vector3(-10, 10, -4);
    }

    // FixedUpdate() runs every frame, but accounts for frame dips and stutters
    // calculates everything more consistently than Update()
    void FixedUpdate() // calculations done in fixedUpdate to preserve frameRate
    {
        if (!targetReached) // while IEnum isn't running
        {
            // set target reached to true
            targetReached = true;

            // set the random Y value
            float randomYValue = Random.Range(minimumYValue, maximumYValue);

            // set the random amt of time to wait b/w movement
            float randomWaitTimer = Random.Range(minimumWaitTime, maximumWaitTime);

            // update the position w/ the new random Y value generated
            StartCoroutine( updatePosition ( new Vector3(-10, randomYValue, -4), randomWaitTimer ) );
        }

        // Functionality to increase counter when fish is in CatchBar
        // Check if collider is in bar every frame
        if (startCounter)
        {
            // If true, increment the counter each frame
            inBoxCounter++;
        }

        // if we're not in the collider bar this frame,
        else if(!startCounter)
        {
            // decrement the counter instead
            inBoxCounter--;
        }

        // decrement overall timer value each frame
        catchTimer--;
    }

    // Update the fish's position
    private IEnumerator updatePosition(Vector3 targetPosition, float randomWait)
    {
        // start the local move timer
        float timer = 0.0f;

        // reset fish's starting position to current position
        Vector3 startPosition = fishTransform.position;

        // reset movementDuration (time spent during movement) to random # specified in inspector
        float movementDuration = Random.Range(minimumMoveSpeed, maximumMoveSpeed);

        // while timer is less than the current movementDuration
        while (timer < movementDuration)
        {
            timer += Time.deltaTime; // set timer to count with seconds

            float t = timer / movementDuration; // t to be used in Lerp formula

            t = t * t * t * (t * (6f * t - 15f) + 10f); // Math.Lerp() formula applied to t

            fishTransform.position = Vector3.Lerp(startPosition, targetPosition, t); // lerp to the new position

            yield return null; // break the IEnum
        }

        yield return new WaitForSeconds(randomWait); // wait for the random # of seconds specified

        targetReached = false; // set targetReached back to false
    }

    // on Trigger enter, set boolean trigger inBox
    void OnTriggerEnter(Collider other)
    {
        // set "startCounter" to true
        startCounter = true; // will run a check in Update()
    }

    void OnTriggerExit(Collider other)
    {
        // set "startCounter" to false
        startCounter = false;
    }

    public void resetTimer() // currently sets catch timer to 1500; change later if you want
    {
        // Reset timers to default values
        inBoxCounter = 0;
        catchTimer = 1500;
    }
}