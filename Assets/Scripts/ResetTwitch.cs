using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResetTwitch : MonoBehaviour
{
    // External References
    [Header("External References")]
    [SerializeField] private GameObject twitchLibGameObject;
    [SerializeField] private float resetDelay;

    // void Start(){}

    // Update is called once per frame
    void Update()
    {
        // If the 1 key is pressed on any frame,
        if(Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            // Switch to IEnumerator function
            StartCoroutine(resetTwitch());
        }
    }

    private IEnumerator resetTwitch()
    {
        // Toggle game object off
        twitchLibGameObject.SetActive(false);

        // Debug
        Debug.Log("Twitch object is turned off. Delay starting...");

        // Wait 2 seconds
        yield return new WaitForSeconds(resetDelay);

        // Toggle game object back on
        twitchLibGameObject.SetActive(true);

        // Debug statement
        Debug.Log("Twitch object has been turned back on.");

        // Stop coroutine
        yield break;
    }
}
