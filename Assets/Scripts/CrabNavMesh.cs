using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrabNavMesh : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float wanderRadius;
    [SerializeField] private float wanderTimer;
    
    // Instance variables
    private Transform goal;
    private NavMeshAgent navMeshAgent;
    private float timer;

    // Called when script is turned on
    public void Awake()
    {
        // get NavMeshAgent of object this script is attached to
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); // for some reason the global doesn't work here?
        timer += Time.deltaTime; // set Timer to increment with time

        // After a certain time,
        if (timer >= wanderTimer) 
        {
            // randomize the new target position as a random Nav Sphere
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            // Set the new destination
            navMeshAgent.SetDestination(newPos);
            // reset the timer
            timer = 0;
        }
        
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) 
    {
        // using insideUnitSphere, which utilizes NavMesh bounds
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        // setting the random direction to origin
        randDirection += origin;
 
        // registering a navmeshhit? not really sure why this is needed
        NavMeshHit navHit;
 
        // Sample a random position on the NavMesh using the random sphere
        NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        // return the new position to be used
        return navHit.position;
    }
}