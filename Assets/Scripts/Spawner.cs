using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Spawner : MonoBehaviour
{
    // External Object References
    [Header("GameObject References")]
    /*[SerializeField]*/ private GameObject crabSpawn;
    /*[SerializeField]*/ private GameObject pizzaSpawn;
    /*[SerializeField]*/ private GameObject bitSpawn;
    /*[SerializeField]*/ private GameObject babyRaysSpawn;
    /*[SerializeField]*/ private GameObject Fish1;
    /*[SerializeField]*/ private GameObject Fish2;
    /*[SerializeField]*/ private GameObject Fish3;
    /*[SerializeField]*/ private GameObject rangoonSpawn;
    /*[SerializeField]*/ private GameObject franksredSpawn;
    /*[SerializeField]*/ private GameObject totinosSpawn;
    [SerializeField] private GameObject audienceSpawn;

    [Header("Bits References")]
    [SerializeField] private GameObject bit1;
    [SerializeField] private GameObject bit100;
    [SerializeField] private GameObject bit1000;
    [SerializeField] private GameObject bit10000;

    [Header("TextMeshPro References")]
    /*[SerializeField]*/ private TextMeshPro crabText;
    [SerializeField] private TextMeshPro audienceText;
    [SerializeField] private TextMeshPro amongusText;
    [SerializeField] private TextMeshPro princeText;
    [SerializeField] private TextMeshPro sansText;
    [SerializeField] private TextMeshPro pusheenText;
    [SerializeField] private TextMeshPro sonicText;
    [SerializeField] private TextMeshPro eggdogText;
    [SerializeField] private TextMeshPro mikuText;
    [SerializeField] private TextMeshPro kermitText;
    [SerializeField] private TextMeshPro birdText;
    [SerializeField] private TextMeshPro skipperText;
    
    // Spawn Radius Settings
    [Header("Spawn Radius Settings")]
    [SerializeField] private float lowerXRange = 15;
    [SerializeField] private float upperXRange = 35;
    [SerializeField] private float yPosition = 10;
    [SerializeField] private float lowerZRange = 6;
    [SerializeField] private float higherZRange = 36;

    [Header("Color Array")]
    [SerializeField] private Material red;
    [SerializeField] private Material orange;
    [SerializeField] private Material yellow;
    [SerializeField] private Material green;
    [SerializeField] private Material blue;
    [SerializeField] private Material purple;

    [Header("Custom Audience Array")]
    [SerializeField] private GameObject amongus;
    [SerializeField] private GameObject prince;
    [SerializeField] private GameObject sans;
    [SerializeField] private GameObject pusheen;
    [SerializeField] private GameObject sonic;
    [SerializeField] private GameObject eggdog;
    [SerializeField] private GameObject miku;
    [SerializeField] private GameObject kermit;
    [SerializeField] private GameObject bird;
    [SerializeField] private GameObject skipper;


    [Header("Audience Settings")]
    [SerializeField] private SkinnedMeshRenderer mRenderer;
    [SerializeField] public List<GameObject> audienceArray;
    public int arrayCounter = 0;
    private GameObject bitHolder;

    [SerializeField] private Vector3 bitPosition = new Vector3(-84f, 2.5f, 82f);

    // Update is called once per frame
    void Update() // switch case would NORMALLY be helpful, but you cannot store Keyboard.current in the new input system
    {
        /*
        // CRAB SPAWNER: LISTENS FOR C
        // checks if c key pressed (new Input system syntax)
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            spawnCrab();
        }
        */
    }

    public void spawnPizza()
    {
        // specify range from inspector
        Vector3 randomPosition = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );

        // Spawn object
        Instantiate(pizzaSpawn, randomPosition, Quaternion.identity);
    }

    public void spawnCrab()
    {
        // specify range from inspector
        Vector3 randomPosition = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );

        // Spawn object
        Instantiate(crabSpawn, randomPosition, Quaternion.identity);
    }

    // overloaded method that takes 1 string parameter to name the crab (pubsub Twitch Username)
    public void spawnCrab(string name)
    {
        // specify range from inspector
        Vector3 randomPosition = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );

        // Spawn object (store first)
        Instantiate(crabSpawn, randomPosition, Quaternion.identity);
        
        crabText.text = name;
    }

    public void spawnBits()
    {
        // specify range from inspector
        Vector3 randomPosition = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );

        // Spawn object
        Instantiate(bitSpawn, randomPosition, Quaternion.identity);
    }

    public void spawnBits(string bitType)
    {
        StartCoroutine(instantiateBits(bitType));
    }

    private IEnumerator instantiateBits(string bType)
    {
        switch(bType)
        {
            case "bit1":
                bit1.SetActive(true);
                yield return new WaitForSeconds(20);
                bit1.SetActive(false);
                yield break;

            case "bit100":
                bit100.SetActive(true);
                yield return new WaitForSeconds(20);
                bit100.SetActive(false);
                yield break;

            case "bit1000":
                bit1000.SetActive(true);
                yield return new WaitForSeconds(20);
                bit1000.SetActive(false);
                yield break;

            case "bit10000":
                bit10000.SetActive(true);
                yield return new WaitForSeconds(20);
                bit10000.SetActive(false);
                yield break;
        } 
    }

    public void spawnBabyRays()
    {
        // specify range from inspector
        Vector3 randomPosition = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );

        // Spawn object
        Instantiate(babyRaysSpawn, randomPosition, Quaternion.identity);
    }
    public void spawnRangoon()
    {
        // specify range from inspector
        Vector3 randomPosition = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );

        // Spawn object
        Instantiate(rangoonSpawn, randomPosition, Quaternion.identity);
    }

    public void spawnTotinos()
    {
        // specify range from inspector
        Vector3 randomPosition = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );

        // Spawn object
        Instantiate(totinosSpawn, randomPosition, Quaternion.identity);
    }

    public void spawnFranksRed()
    {
        // specify range from inspector
        Vector3 randomPosition = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );

        // Spawn object
        Instantiate(franksredSpawn, randomPosition, Quaternion.identity);
    }

    public void spawnFish()
    {
        // specify range from inspector
        Vector3 randomPosition = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );
        // Fish index range (hardcoded for now, can be made dynamic later)
        int index = Random.Range(0, 3);

        if (index == 0)
        {
            Instantiate(Fish1, randomPosition, Quaternion.identity);
        }

        if (index == 1)
        {
            Instantiate(Fish2, randomPosition, Quaternion.identity);
        }

        if (index == 2)
        {
            Instantiate(Fish3, randomPosition, Quaternion.identity);
        }

        else{}                                  
    }

    // spawn audience member: NO COLOR SPECIFIED
    public void spawnAudience(string thisName)
    {
        if (thisName == null)
        {
            Debug.Log("Username field is null.");
        }

        // specify spawn range from inspector
        Vector3 randomPosition = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );

        // chance audienceText name to username supplied by pubsub
        audienceText.text = thisName;

        // the prefab spawns in facing stage right, but I want it to face the stage
        // rotate the spawn point by creating a quaternion euler angle of +90 on the Y axis
        Quaternion spawnRotation = Quaternion.Euler(0,90,0);

        // spawn object
        GameObject clone = Instantiate(audienceSpawn, randomPosition, spawnRotation);
        clone.name = thisName;

        audienceArray.Add(clone);
        arrayCounter++;

        Debug.Log(clone.name);

        if (clone ==  null)
        {
            Debug.Log("Clone is null.");
        }

        // set audienceText back to null
        // audienceText.text = "";
    }

    // spawn in audience member: COLOR SPECIFIED
    public void spawnAudience(string thisName, string color)
    {
        switch(color.ToLower())
        {
            case "red":
                // assign red material to clone
                mRenderer.material = red;
                break;
            case "orange":
                // assign orange material to clone
                mRenderer.material = orange;
                break;
            case "yellow":
                // assign yellow material to clone
                mRenderer.material = yellow;
                break;
            case "green":
                // assign green material to clone
                mRenderer.material = green;
                break;
            case "blue":
                // assign blue material to clone
                mRenderer.material = blue;
                break;
            case "purple":
                // assign purple material to clone
                mRenderer.material = purple;
                break;
            default:
                // do nothing
                break;
        }

        if (thisName == null)
        {
            Debug.Log("Username field is null.");
        }

        // specify spawn range from inspector
        Vector3 randomPosition = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );

        // chance audienceText name to username supplied by pubsub
        audienceText.text = thisName;

        // the prefab spawns in facing stage right, but I want it to face the stage
        // rotate the spawn point by creating a quaternion euler angle of +90 on the Y axis
        Quaternion spawnRotation = Quaternion.Euler(0,90,0);

        // spawn object
        GameObject clone = Instantiate(audienceSpawn, randomPosition, spawnRotation);
        clone.name = thisName;

        audienceArray.Add(clone);
        arrayCounter++;

        // Debug.Log(clone.name);

        if (clone ==  null)
        {
            Debug.Log("Clone is null.");
        }

        // set audienceText back to null
        audienceText.text = "";
    }

    // I know this is bad practice and bloated
    // I was on a fuckin schedule I'll refactor it LATER
    // Spawn a custom audience avatar : specified by user
    public void spawnCustomAudience(string thisName, string avatarChoice)
    {
        if (thisName == null || avatarChoice == null)
        {
            Debug.Log("spawnCustomAudience: username or avatar choice was null.");
        }

        switch(avatarChoice.ToLower())
        {
            case "amongus":
                // specify range from inspector
                Vector3 randomPosition = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );

                // assign text
                amongusText.text = thisName;

                // spawn object
                GameObject clone = Instantiate(amongus, randomPosition, Quaternion.identity);
                clone.name = thisName;

                // Add to audience array
                audienceArray.Add(clone);
                arrayCounter++;

                // Debug
                if (clone ==  null)
                {
                    Debug.Log("Clone is null.");
                }
                break;

            case "prince":
                // specify range from inspector
                Vector3 randomPosition1 = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );

                // assign text
                princeText.text = thisName;

                // spawn object
                GameObject clone1 = Instantiate(prince, randomPosition1, Quaternion.identity);
                clone1.name = thisName;

                // Add to audience array
                audienceArray.Add(clone1);
                arrayCounter++;

                // Debug
                if (clone1 ==  null)
                {
                    Debug.Log("Clone is null.");
                }
                break;
            case "sans":
                // specify range from inspector
                Vector3 randomPosition2 = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );

                // assign text
                sansText.text = thisName;

                // spawn object
                GameObject clone2 = Instantiate(sans, randomPosition2, Quaternion.identity);
                clone2.name = thisName;

                // Add to audience array
                audienceArray.Add(clone2);
                arrayCounter++;

                // Debug
                if (clone2 ==  null)
                {
                    Debug.Log("Clone is null.");
                }
                break;
            case "pusheen":
                // specify range from inspector
                Vector3 randomPosition3 = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );

                // assign text
                pusheenText.text = thisName;

                // spawn object
                GameObject clone3 = Instantiate(pusheen, randomPosition3, Quaternion.identity);
                clone3.name = thisName;

                // Add to audience array
                audienceArray.Add(clone3);
                arrayCounter++;

                // Debug
                if (clone3 ==  null)
                {
                    Debug.Log("Clone is null.");
                }
                break;
            case "sonic":
                // specify range from inspector
                Vector3 randomPosition4 = new Vector3( Random.Range(lowerXRange, upperXRange), 4.31f, Random.Range(lowerZRange, higherZRange) );

                // assign text
                sonicText.text = thisName;

                // spawn object
                GameObject clone4 = Instantiate(sonic, randomPosition4, Quaternion.identity);
                clone4.name = thisName;

                // Add to audience array
                audienceArray.Add(clone4);
                arrayCounter++;

                // Debug
                if (clone4 ==  null)
                {
                    Debug.Log("Clone is null.");
                }
                break;
            case "eggdog":
                // specify range from inspector
                Vector3 randomPosition5 = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );

                // assign text
                eggdogText.text = thisName;

                // spawn object
                GameObject clone5 = Instantiate(eggdog, randomPosition5, Quaternion.identity);
                clone5.name = thisName;

                // Add to audience array
                audienceArray.Add(clone5);
                arrayCounter++;

                // Debug
                if (clone5 ==  null)
                {
                    Debug.Log("Clone is null.");
                }
                break;
            case "miku":
                // specify range from inspector
                Vector3 randomPosition6 = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );

                // assign text
                mikuText.text = thisName;

                // spawn object
                GameObject clone6 = Instantiate(miku, randomPosition6, Quaternion.identity);
                clone6.name = thisName;

                // Add to audience array
                audienceArray.Add(clone6);
                arrayCounter++;

                // Debug
                if (clone6 ==  null)
                {
                    Debug.Log("Clone is null.");
                }
                break;
            case "kermit":
                // specify range from inspector
                Vector3 randomPosition7 = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );

                // assign text
                kermitText.text = thisName;

                // spawn object
                GameObject clone7 = Instantiate(kermit, randomPosition7, Quaternion.identity);
                clone7.name = thisName;

                // Add to audience array
                audienceArray.Add(clone7);
                arrayCounter++;

                // Debug
                if (clone7 ==  null)
                {
                    Debug.Log("Clone is null.");
                }
                break;
            case "bird":
                // specify range from inspector
                Vector3 randomPosition8 = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );

                // assign text
                birdText.text = thisName;

                // spawn object
                GameObject clone8 = Instantiate(bird, randomPosition8, Quaternion.identity);
                clone8.name = thisName;

                // Add to audience array
                audienceArray.Add(clone8);
                arrayCounter++;

                // Debug
                if (clone8 ==  null)
                {
                    Debug.Log("Clone is null.");
                }
                break;
            case "skipper":
                // specify range from inspector
                Vector3 randomPosition9 = new Vector3( Random.Range(lowerXRange, upperXRange), yPosition, Random.Range(lowerZRange, higherZRange) );

                // assign text
                skipperText.text = thisName;

                // the prefab spawns in facing stage right, but I want it to face the stage
                // rotate the spawn point by creating a quaternion euler angle of +90 on the Y axis
                Quaternion spawnRotation = Quaternion.Euler(0,90,0);

                // spawn object
                GameObject clone9 = Instantiate(skipper, randomPosition9, spawnRotation);
                clone9.name = thisName;

                // Add to audience array
                audienceArray.Add(clone9);
                arrayCounter++;

                // Debug
                if (clone9 ==  null)
                {
                    Debug.Log("Clone is null.");
                }
                break;
            default:
                Debug.Log("Error in Clone instantiation process: Custom Audience Spawn");
                // do nothing
                break;
        }
    }
}
