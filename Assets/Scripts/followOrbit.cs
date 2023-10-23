using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple script to make the vCam orbit on the Y axis
// Increments the Y rotational value by a set value each frame

public class followOrbit : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float orbitingSpeed;

    // Update is called once per frame
    void Update()
    {
        // Every frame, increase orbiting camera's Y rotation value by the orbitingSpeed value
        transform.Rotate(0, orbitingSpeed * Time.deltaTime, 0);
    }
}
