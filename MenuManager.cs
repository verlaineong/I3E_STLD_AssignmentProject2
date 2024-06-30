/*
 * Author: Verlaine Ong
 * Date: 26/6/2024
 * Description: 
 * Contains functions related to menu
 */
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Canvas menuCanvas;// menu Canvas GameObject
    private bool isMenuOpen = false; // Track if the menu is currently open


    /// <summary>
    /// function to hide cursor at firsr 
    /// </summary>
    void Start()
    {
        CloseMenu(); // Ensure the menu starts closed
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// function to open the menu when player press F
    /// </summary>
    void Update()
    {
        // Toggle menu when pressing the "F" key
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleMenu();
        }
    }
    /// <summary>
    /// function to open menu
    /// </summary>
    void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;

        if (isMenuOpen)
        {
            OpenMenu();
        }
        else
        {
            CloseMenu();
        }
    }
    /// <summary>
    /// Function to show the menu Canvas and make the cursor visible
    /// </summary>
    void OpenMenu()
    {
        menuCanvas.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// function to hide the menu Canvas and hide the cursor
    /// </summary>
    void CloseMenu()
    {
        menuCanvas.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}