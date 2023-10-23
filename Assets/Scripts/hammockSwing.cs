using UnityEngine;
using System.Collections;

// Simple script to sway the hammock camera back and forth using Lerp()

public class hammockSwing : MonoBehaviour
{
    // starting point World Position: 10, 7.6, 23
    // ending point World Position:    7, 7.6, 25
    [Header("Settings")]
    [SerializeField] private Vector3 pointB;
   
    // Start begins as a coroutine
    IEnumerator Start()
    {
        // Point A of the Lerp is the starting position of the object script is attached to
        Vector3 pointA = transform.position;

        // While the Start() coroutine is active
        while(true)
        {
            // First, run the A -> B coroutine
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
            // Second, run the B -> A coroutine (same coroutine, but values swapped)
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
        }
    }
   
    // Coroutine to move the object via Lerp from a specified starting position -> ending position
    IEnumerator MoveObject(Transform thisTransform, Vector3 startPosition, Vector3 endPosition, float time)
    {
        float i = 0.0f;
        float rate = 1.0f / time;

        while(i < 1.0f)
        {
            // Set the speed and multiply by realtime
            i += Time.deltaTime * rate;
            // Lerp from start pt -> end point using the speed calculated in line 37
            thisTransform.position = Vector3.Lerp(startPosition, endPosition, i);
            // return to coroutine call
            yield return null;
        }
    }
}