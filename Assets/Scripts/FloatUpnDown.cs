using UnityEngine;
using System.Collections;

// Makes objects float up & down while gently spinning.
public class FloatUpnDown : MonoBehaviour 
{
	[Header("Text Settings")]
	[SerializeField] private float degreesPerSecond = 15.0f; // Degrees of ROTATION performed per second (set to 0 if you don't want rotation)
	[SerializeField] private float amplitude = 0.5f;
	[SerializeField] private float frequency = 1f;

	// Instance Variables
	private Vector3 positionOffset = new Vector3 ();
	private Vector3 temporaryPosition = new Vector3 ();

	// Use this for initialization
	void Start () 
	{
		// Store the starting position & rotation of the object
		positionOffset = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Spin object around Y-Axis
		transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

		// Store the temporary position as the position offset
		temporaryPosition = positionOffset;

		// Float up/down animation with Mathf.Sin formula
		temporaryPosition.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;

		transform.position = temporaryPosition;
	}
}
