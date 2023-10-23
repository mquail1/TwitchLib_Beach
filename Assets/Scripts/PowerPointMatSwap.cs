using UnityEngine;
using UnityEngine.InputSystem;

public class PowerPointMatSwap : MonoBehaviour
{
    [Header("GameObject references")]
    [SerializeField] private Material[] pptMaterials; // material array
    [SerializeField] private MeshRenderer meshRenderer;

    // Instance Variables
    private int index = 0; // where we can swap the index

    // Start is called before the first frame update
    void Start()
    {
        // grab reference to mesh renderer this script is attached to
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // reset index when hitting last slide
        if (index == 8)
        {
            index = 0;
        }

        // 0 key allows us to traverse through array like a PowerPoint
        if ((Keyboard.current.digit0Key.wasPressedThisFrame))
        {
            // increment i
            index++;
            
            // display material at position i
            meshRenderer.material = pptMaterials[index];
        }
    }

    /*
    public void swapMat()
    {
        // reset index when hitting last slide
        if (index == 8)
        {
            index = 0;
        }

        // increment i
        index++;
        
        // display material at position i
        meshRenderer.material = pptMaterials[index];
    }
    */
}
