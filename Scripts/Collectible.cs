/*
 * Author: Verlaine Ong
 * Date: 17/6/2024
 * Description: 
 * The Collectible will destroy itself after being collided with.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Interactable  //everything u type inside the interactable script can use inside this script
{
    /// <summary>
    /// The score value that this collectible is worth.
    /// </summary>
    public static int myScore = 1;

    public Canvas itemImage;
   

    public static bool hasCrystal = false;
    public static bool hasMaterial = false;
    public static bool hasEngine = false;

    /// <summary>
    /// Performs actions related to collection of the collectible
    /// </summary>
    void Start()
    {
        itemImage.gameObject.SetActive(false);

    }
    public void Collected()
    {
        // Activate the corresponding UI image based on the game object's tag
        if (gameObject.tag == "Crystal")
        {
            itemImage.gameObject.SetActive(true);
            hasCrystal = true;
        }
        else if (gameObject.tag == "Material")
        {
            itemImage.gameObject.SetActive(true);
            hasMaterial = true;
        }
        else if (gameObject.tag == "Engine")
        {
            itemImage.gameObject.SetActive(true);
            hasEngine = true;
        }

        // Destroy the attached GameObject
        Destroy(gameObject);
    }

    /// <summary>
    /// Callback function for when a collision occurs
    /// </summary>
    /// <param name="collision">Collision event data</param>
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object that touched me has a 'Player' tag
        if (collision.gameObject.tag == "Player")
        {
            // Look for player component on object that collided with me
            currentPlayer = collision.gameObject.GetComponent<Player>();
            // Update the player that I'm a current collectible
            UpdatePlayerInteractable(currentPlayer);
        }
    }

    /// <summary>
    /// Callback function for when a collision stopped
    /// </summary>
    /// <param name="collision">Collision event data</param>
    private void OnCollisionExit(Collision collision)
    {
        // Check if the object that stopped touching me has a 'Player' tag
        if (collision.gameObject.tag == "Player")
        {
            // Remove player component on object that collided with me
            RemovePlayerInteractable(currentPlayer);
            // Update the player that there is no current collectible.
            currentPlayer = null;
        }
    }

    /// <summary>
    /// Handles the collectible's interaction.
    /// Increases the player's score and destroys itself
    /// </summary>
    /// <param name="thePlayer">The player that interacted with the object.</param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        GameManager.Instance.IncreaseScore(myScore);
        ActivateEnhancements(thePlayer); // Call this to enhance
        Collected();
    }

    /// <summary>
    /// Activates enhancements on the player.
    /// </summary>
    private void ActivateEnhancements(Player thePlayer)
    {
        Enhancement enhancement = thePlayer.GetComponent<Enhancement>();
        if (enhancement != null)
        {
            enhancement.isEnhancedMode = true;
        }
    }
}