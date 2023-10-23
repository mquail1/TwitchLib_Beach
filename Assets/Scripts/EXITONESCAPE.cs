using UnityEngine;
using UnityEngine.InputSystem;

public class EXITONESCAPE : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }
    }
}
