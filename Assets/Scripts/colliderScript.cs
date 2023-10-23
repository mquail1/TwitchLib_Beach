using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to run becomeCrabRangoon() IEnum when collider is triggered on Firepit object

public class colliderScript : MonoBehaviour
{
    [Header("Script Reference")]
    [SerializeField] private CrabMeshSwap crabMeshSwap;

    // When entering the trigger on this object,
    void OnTriggerEnter(Collider other)
    {
        // check if a Crab was the one to trip the collider
        if (other.gameObject.tag == "Crab")
        {
            // start coroutine becomeCrabRangoon() via crabMeshSwap script referenced
            StartCoroutine(crabMeshSwap.becomeCrabRangoon());
        }
    }
}
