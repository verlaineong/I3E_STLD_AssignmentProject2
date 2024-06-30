/*
 * Author: Verlaine Ong
 * Date: 26/5/2024
 * Description: 
 * function to change scene to 0 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstScene: MonoBehaviour
{
    /// <summary>
    /// a function to change scene
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(0);

    }

}
