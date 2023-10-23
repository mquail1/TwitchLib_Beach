using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshSwapTest : MonoBehaviour
{
    [SerializeField] private Material[] materialArray;
    [Header("Settings")]
    [SerializeField] private SkinnedMeshRenderer meshRenderer;
    // [SerializeField] private Material debugMaterial;
    private Material currentMaterial;


    // Start is called before the first frame update
    void Start()
    {
        // debug
        // meshRenderer.material = debugMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
