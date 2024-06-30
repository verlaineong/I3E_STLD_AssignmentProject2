/*
 * Author: Verlaine Ong
 * Date: 17/6/2024
 * Description: 
 *  Canvas Ui hide and show
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public Canvas PausePanel;

    /// <summary>
    /// A function to hide canvas ui at the start 
    /// </summary>
    public void Start()
    {
        PausePanel.gameObject.SetActive(false);

    }

    /// <summary>
    /// A function to show canvas ui
    /// </summary>
    public void Pause()
    {
        PausePanel.gameObject.SetActive(true);
        
    }

    /// <summary>
    /// A function to hide canvas ui
    /// </summary>
    public void Continue()
    {
        PausePanel.gameObject.SetActive(false);
       
    }
     

}
