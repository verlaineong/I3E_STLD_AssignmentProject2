
/*
 * Author: Verlaine Ong
 * Date: 26/5/2024
 * Description: 
 * Contains functions to open canvas
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{

  
    public Canvas InstructionPanel;

    /// <summary>
    /// function to hide canvas 
    /// </summary>
    public void Start()
    {
        InstructionPanel.gameObject.SetActive(false);


    }
    /// <summary>
    /// function to show canvas
    /// </summary>
 
    public void Pause()
    {
        InstructionPanel.gameObject.SetActive(true);
        
    }

    /// <summary>
    /// function to hide canvas
    /// </summary>

    public void Continue()
    {
        InstructionPanel.gameObject.SetActive(false);
       
    }
     

}
