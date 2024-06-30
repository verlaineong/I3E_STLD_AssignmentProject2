
/*
 * Author: Verlaine Ong
 * Date: 17/6/2024
 * Description: 
 * It will spawn rocks when the player touch the ground.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    public Spawner spawner; 
    public float spawnInterval = 0.5f; // Time interval between spawns in seconds
    /// <summary>
    /// A bool check if the player is on the platform
    /// </summary>
    private bool isPlayerOnPlatform = false; 
    /// <summary>
    /// A float to track spawn intervals
    /// </summary>
    private float spawnTimer = 0f;



    /// <summary>
    /// A function to check if the object that entered the trigger has the player tag
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnPlatform = true; // player enters
        }
    }
    /// <summary>
    /// A function to check if the object that exit the trigger has the player tag
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
     
        if (other.CompareTag("Player"))
        {
            isPlayerOnPlatform = false; // player exits
        }
    }

    /// <summary>
    /// A function to spawn the rocks each intervals.
    /// </summary>
    private void Update()
    {
        // Check if player is on the platform
        if (isPlayerOnPlatform)
        {
            // Increment the spawnTimer by the time since the last frame ( a unity property )
            spawnTimer += Time.deltaTime;

            // Check if the time is more than and equal to the supposingly spwn timing
            if (spawnTimer >= spawnInterval)
            {
                // Spawn the rock object 
                spawner.SpawnRock();

                // Reset spawnTimer to 0 after spawning
                spawnTimer = 0f;
            }
        }
    }
}