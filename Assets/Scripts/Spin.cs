using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Extremely simple script to spin an object

public class Spin : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float floatX;
    [SerializeField] private float floatY;
    [SerializeField] private float floatZ;

    // Update is called once per frame
    void Update()
    {
        // every frame, rotate the desired increment on the desired axis
        transform.Rotate(new Vector3(floatX, floatY, floatZ));
    }
}
