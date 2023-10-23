using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTriggerEnterController : MonoBehaviour
{
    [Header("GameObject References")]
    [SerializeField] private GameObject pleaText;

    // when entering collider zone, turn hammock camera on
    void OnCollisionEnter(Collision other)
    {
        // check if Player was the one to trip the collider
        if (other.gameObject.tag == "Player")
        {
            // "Relax in Hammock" text appears when in Trigger zone only
            pleaText.SetActive(true);
        }
    }

    // on when exiting collider zone, turn off hammock camera
    void OnCollisionExit(Collision other)
    {
        // check if Player was the one to trip the collider
        if (other.gameObject.tag == "Player")
        {
            // "Relax in Hammock" text disappear on Trigger exit
            pleaText.SetActive(false);
        }
    }
}
