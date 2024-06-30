
/*
 * Author: Verlaine Ong
 * Date: 26/5/2024
 * Description: 
 * Contains functions for cursor
 */

using UnityEngine;

public class CursorManager : MonoBehaviour
{

    /// <summary>
    /// function to make cursor visible
    /// </summary>
    void Start()
    {
        // Ensure the cursor is visible and unlocked initially
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// function to hide cursor
    /// </summary>
    public void ToggleCursor()
    {
        Cursor.visible = !Cursor.visible;
        Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
    }
}