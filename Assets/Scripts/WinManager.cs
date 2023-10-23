using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to control the winning game condition
// this is separate from FishGame because of the complex nature of waiting b/w calls
// does not work properly in FishGame.cs, so moved functionality to here

public class WinManager : MonoBehaviour
{
    [Header("GameObject References")]
    [SerializeField] GameObject winManager;
    [SerializeField] GameObject winningFishDisplay;

    [Header("Settings")]
    [SerializeField] private float secondsToWait;

    void Start()
    {
        StartCoroutine(LateCall(secondsToWait));
    }

    IEnumerator LateCall(float seconds)
    {
        Debug.Log("LateCall() in WinManager entered.");
        // wait for specified number of seconds set in Inspector
        yield return new WaitForSeconds(seconds);

        // if either of the items are active in the display,
        if (winningFishDisplay.activeInHierarchy)
        {
            // set them to false
            winningFishDisplay.SetActive(false);
            // winCam.SetActive(false);
        }

        Debug.Log("LateCall() in WinManager exited.");
        winManager.SetActive(false); // set the game manager itself to false
    }
}
