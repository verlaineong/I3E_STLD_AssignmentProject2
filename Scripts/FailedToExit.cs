/*
 * Author: Verlaine Ong
 * Date: 28/6/2024
 * Description: 
 * Player collide and change scene
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailedToExit : MonoBehaviour
{
    /// <summary>
    /// Function for player colliding with the object and change scene.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object that touched me has a 'Player' tag
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadSceneAsync(3);
        }
    }

}
