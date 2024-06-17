/*
 * Author: Verlaine Ong
 * Date: 26/5/2024
 * Description: 
 * Contains functions related to the Player such as increasing score.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    /// <summary>
    /// The UI text that stores the player score
    /// </summary>
    public TextMeshProUGUI scoreText;

    /// <summary>
    /// The current score of the player
    /// </summary>
    /// int currentScore = 0;

    /// <summary>
    /// The current Interactable of the player
    /// </summary>
    Interactable currentInteractable;

    [SerializeField]
    Transform playerCamera;

    [SerializeField]
    float interactionDistance;

    private void Update()
    {
        Debug.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);
        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            ///print out name when ray hit
            Debug.Log(hitInfo.transform.name);
        }
    }

    private Door currentDoor;
    private Collectible currentCollectible;


    /// <summary>
    /// Increases the score of the player by <paramref name="scoreToAdd"/>
    /// </summary>
    /// <param name="scoreToAdd">The amount to increase by</param>
    //public void IncreaseScore(int scoreToAdd)
    //{
    //    // Increase the score of the player by scoreToAdd
    //    currentScore += scoreToAdd;
    //
    //    scoreText.text = "Score: " + currentScore.ToString();
    //}

    /// <summary>
    /// Update the player's current Interactable
    /// </summary>
    /// <param name="newInteractable">The interactable to be updated</param>
    public void UpdateInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
    }
    /// <summary>
    /// remove the player's current Interactable
    /// </summary>
    public void RemoveInteractable()
    {
        currentInteractable = null;
    }
    /// <summary>
    /// Update the door
    /// </summary>
    public void UpdateDoor(Door newDoor)
    {
        currentDoor = newDoor;
    }
    /// <summary>
    /// Update the collectible 
    /// </summary>
    public void UpdateCollectible(Collectible newCollectible)
    {
        currentCollectible = newCollectible;
    }

    /// <summary>
    /// Callback function for the Interact input action
    /// </summary>
    void OnInteract()
    {
        // Check if the current Interactable is null
        if (currentInteractable != null)
        {
            // Interact with the object
            currentInteractable.Interact(this);
        }
    }
}
