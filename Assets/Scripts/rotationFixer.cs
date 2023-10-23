using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple script to fix rotation issues
// Sets all rotation values to 0

public class rotationFixer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Grab reference to rigidbody attached to this gameobject
        Rigidbody rb = GetComponent<Rigidbody>();
        // Set rigidbody Vector3 transform, rotation, and CoM to 0
        rb.centerOfMass = Vector3.zero;
        rb.inertiaTensorRotation = Quaternion.identity;
        rb.centerOfMass = Vector3.zero;
    }
}
