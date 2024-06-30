/*
 * Author: Verlaine Ong
 * Date: 17/6/2024
 * Description: 
 * It will spawn rocks 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject rockObject;

    /// <summary>
    /// A function to spawn rocks.
    /// </summary>
    public void SpawnRock()
    {
        Instantiate(rockObject, transform.position, Quaternion.identity);
    }
}
