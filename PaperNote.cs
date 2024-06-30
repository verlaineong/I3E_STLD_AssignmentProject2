/*
 * Author: Verlaine Ong
 * Date: 29/6/2024
 * Description: 
 * Contains functions for paper note canvas
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperNote : MonoBehaviour
{
    public Canvas paperNote;

    /// <summary>
    /// Function to deactive the canvas at the start
    /// </summary>
    void Start()
    {
        paperNote.gameObject.SetActive(false);
    }

    /// <summary>
    /// Function to active the canvas when the object is collected and player press Q
    /// </summary>
    void Update()
    {
        if (Collectible.hasNote && Input.GetKeyDown(KeyCode.Q))
        {
            paperNote.gameObject.SetActive(!paperNote.gameObject.activeSelf);
        }
    }
}
