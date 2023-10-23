using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to move seagulls in a circle
// Does not work because the seagulls are parented weird in the hierarchy
// However, a useful script for future reference

[RequireComponent(typeof(Rigidbody))] // Requires Rigidbody to move around

public class SeagullMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float timeCounter = 0;
    [SerializeField] private float speed;
    [SerializeField] private float width;
    [SerializeField] private float height;

    void Start()
    {
        // Debug
        // Debug.Log(transform.position);
    }

    void Update()
    {
        timeCounter += Time.deltaTime * speed;

        float x = Mathf.Cos(timeCounter) * width;
        float y = Mathf.Sin(timeCounter) * height;
        // float z = 0;

        transform.position = new Vector3(x + 28, 200, y + 27);
    }
}