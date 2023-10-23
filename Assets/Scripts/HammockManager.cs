using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

// Toggles ability to swing back and forth in the hammock ONLY when within collider range

public class HammockManager : MonoBehaviour
{
    [Header("GameObject references")]
    [SerializeField] private GameObject hammockContain;
    [SerializeField] private GameObject relaxInHammock;

    [Header("Settings")]
    [SerializeField] private float waitTime;

    private bool inBoundary = false;

    // Update runs every frame
    void Update()
    {
        // pressing f key in bounds turns on camera
        if (Keyboard.current.eKey.wasPressedThisFrame && inBoundary)
        {
            // deactivate player Camera
            hammockContain.SetActive(true);
            StartCoroutine(relaxForAwhile());
        }
    }

    // IEnum to active hammock container game object
    private IEnumerator relaxForAwhile()
    {
        relaxInHammock.SetActive(false);
        // wait for specified number of seconds
        yield return new WaitForSeconds(waitTime);

        hammockContain.SetActive(false);
        yield break;
    }

    // when entering collider zone, turn hammock camera on
    void OnTriggerEnter(Collider other)
    {
        // check if Player was the one to trip the collider
        if (other.gameObject.tag == "Player")
        {
            // "Relax in Hammock" text appears when in Trigger zone only
            relaxInHammock.SetActive(true);

            // set "inBounds" to true
            inBoundary = true;
        }
    }


    // on when exiting collider zone, turn off hammock camera
    void OnTriggerExit(Collider other)
    {
        // check if Player was the one to trip the collider
        if (other.gameObject.tag == "Player")
        {
            // "Relax in Hammock" text disappear on Trigger exit
            relaxInHammock.SetActive(false);

            // set "inBounds" to false
            inBoundary = false;
        }
    }
}
