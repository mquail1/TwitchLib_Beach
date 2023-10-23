using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

// Simple script to animate Cinemachine Dolly moving forward

public class dollyMove : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private float speed;

    void Update()
    {
        transform.Translate( Vector3.forward * speed * Time.deltaTime );
    }
}