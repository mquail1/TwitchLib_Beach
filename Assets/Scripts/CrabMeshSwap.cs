using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrabMeshSwap : MonoBehaviour
{
    [Header("Mesh References")]
    [SerializeField] private Mesh crabMesh;
    [SerializeField] private Mesh crabRangoonMesh;

    [Header("Material References")]
    [SerializeField] private Material rangoonMat;
    [SerializeField] private Material crabMat;

    [Header("Settings")]
    [SerializeField] private float timeTransformed;

    // IEnum to turn crab mesh into the crab rangoon mesh, then back after a specified amt of time
    public IEnumerator becomeCrabRangoon()
    {
        Debug.Log("Entered becomeCrabRangoon IEnum.");
        // switch to crab rangoon mesh
        GetComponent<SkinnedMeshRenderer>().sharedMesh = crabRangoonMesh;

        // switch to crab rangoon mat
        GetComponent<SkinnedMeshRenderer>().material = rangoonMat;

        // wait specified number of time in inspector
        yield return new WaitForSeconds(timeTransformed);

        // swap back to crab mesh
        GetComponent<SkinnedMeshRenderer>().sharedMesh = crabMesh;

        // swap back to crab mat
        GetComponent<SkinnedMeshRenderer>().material = crabMat;

        // exit
        yield break;
    }
}
