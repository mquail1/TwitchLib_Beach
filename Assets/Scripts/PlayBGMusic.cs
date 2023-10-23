using UnityEngine;
using UnityEngine.InputSystem;

// Script to start playing sounds when down key is pressed

public class PlayBGMusic : MonoBehaviour
{
    [Header("Audio References")]
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource startupSound;

    // Update is called once per frame
    void FixedUpdate()
    {
        // check for down arrow input (hotkey) in new Input System
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            backgroundMusic.Play();
            startupSound.Play();
        }
    }
}
