using UnityEngine;
using UnityEngine.InputSystem;

// Disallows PlayerCam vcam on startup
// Toggles vCam to on after check is referenced (any input happens on the new Input system)

public class PlaySounds : MonoBehaviour
{
    [Header("GameObject References")]
    [SerializeField] private GameObject soundSystem;

    // Awake called once on build startup
    void Awake()
    {
        // reference virtual camera when program starts
        GameObject soundSystem = gameObject.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // check for any user input in new Input System
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            // set soundSystem game object to active
            soundSystem.gameObject.SetActive(true);
        }
    }
}
