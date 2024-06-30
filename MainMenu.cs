
/*
 * Author: Verlaine Ong
 * Date: 26/5/2024
 * Description: 
 * Contains functions to change scene to scene 1
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
 /// <summary>
 /// A function to start game
 /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
        
    }

}
