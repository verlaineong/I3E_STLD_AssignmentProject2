/*
 * Author: Verlaine Ong
 * Date: 17/6/2024
 * Description: 
 * Change scene to scene 2
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    /// <summary>
    /// The function to change scene.
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadSceneAsync(2);
        
    }

}
