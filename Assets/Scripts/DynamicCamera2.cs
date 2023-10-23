using UnityEngine;
using UnityEngine.InputSystem;

// Script to manage camera setup: 
// PlayerCam vcam automatically disabled on startup
// ScreenCam vcam enabled on startup
// Toggles vCam to on after update check is performed

public class DynamicCamera2 : MonoBehaviour
{   
    // External Object References
    [Header("External Camera References")]
    [SerializeField] private GameObject playerFollowCamera;
    [SerializeField] private GameObject crabCamera;
    
    // Instance Variables
    private bool crabOn = false;

    // Awake called once on build startup
    void Awake()
    {
        // reference virtual cameras attached to this game object
        GameObject playerFollowCamera = gameObject.GetComponent<GameObject>();
        GameObject crabCamera = gameObject.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // check for down arrow input (hotkey) in new Input System
        // prompts the vCam enable, which will activate hierarchy -> state machine transition
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            playerFollowCamera.gameObject.SetActive(true);
        }

        // checks for up arrow input (hotkey) in new Input System
        // prompts the crabCam vCam enable, which will activate hierarchy -> state machine transition
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            if (crabOn == false)
            {
                crabCamera.gameObject.SetActive(true);
                crabOn = true;
            }

            else if (crabOn == true)
            {
                crabCamera.gameObject.SetActive(false);
                crabOn = false;
            }
        }
    }
}
