/*
 * Author: Verlaine Ong
 * Date: 17/6/2024
 * Description: 
 * Scene changes when player collide with object
 */
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    /// <summary>
    /// An integer to key in the scene to change to.
    /// </summary>
    public int targetScene = 0;

    /// <summary>
    /// A function to change scene when player collide.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            // do scene change here.
            ChangeScene();
        }
    }
    /// <summary>
    /// A function to change scene.
    /// </summary>
    void ChangeScene() 
    {
        SceneManager.LoadScene(targetScene);
    }
   
}
