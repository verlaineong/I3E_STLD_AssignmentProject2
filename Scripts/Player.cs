/*
 * Author: Verlaine Ong
 * Date: 
 * Description: 
 * Contains functions related to the Player such as increasing score.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    /// <summary>
    /// The UI text that stores the player score
    /// </summary>
    public TextMeshProUGUI scoreText;

    public HealthBar mHealthBar;
    public Canvas Hud;
    public GameObject gameOverPanel;


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


    private Rigidbody rb; // Reference to Rigidbody component


    private void Start()
    {
       
        gameOverPanel.gameObject.SetActive(false);
        mHealthBar = Hud.transform.Find("HealthBar").GetComponent<HealthBar>();
        mHealthBar.Min = 0;
        mHealthBar.Max = Health;
        
        
    }


    public int Health = 100;

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0)
        {
            Health = 0;
        }

        if (mHealthBar != null)
        {
            mHealthBar.SetHealth(Health);
        }

        if (Health == 0)
        {
            Die();

        }

    }
    public void Die()
    {
        // Rotate the player capsule 90 degrees forward
        transform.Rotate(Vector3.forward * 90);

        // Start the coroutine to wait and load the scene
        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {
        // Wait for 3 seconds 
        yield return new WaitForSeconds(3f);

        // Load the next scene
        SceneManager.LoadSceneAsync(3);
    }

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





 
    Door currentDoor;
    Collectible currentCollectible;


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
        // Check if there is a current interactable
        if (currentInteractable != null)
        {
            // Interact with the current interactable
            currentInteractable.Interact(this);
        }

        // Check if there is a current door
        if (currentDoor != null)
        {
            // Open the door
            currentDoor.OpenDoor();
        }
    }



}