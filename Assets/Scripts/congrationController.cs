using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class congrationController : MonoBehaviour
{
    [Header("GameObject references")]
    [SerializeField] private GameObject congrationControl;
    private bool playedAlready = false;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.downArrowKey.wasPressedThisFrame && !playedAlready)
        {
            playedAlready = true;
            StartCoroutine(delayStart());
        }
    }

    private IEnumerator delayStart()
    {
        yield return new WaitForSeconds(2);

        congrationControl.SetActive(true);

        yield return new WaitForSeconds(5);

        congrationControl.SetActive(false);
    }
}
