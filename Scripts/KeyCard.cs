/*
 * Author:
 * Date: 06/05/2024
 * Description: 
 * The KeyCard will destroy itself after being collided with.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    /// <summary>
    /// The door that this key card unlocks
    /// </summary>
    public Door linkedDoor;
    public Canvas itemImage;

    public static bool has01 = false;
    public static bool has05 = false;
    public static bool hasCr = false;
    public static bool hasL = false;

    private bool playerInRange = false;
    private GameObject player;

    private void Start()
    {
        // Check if there is a linked door
        if (linkedDoor != null)
        {
            // Lock the door that is linked
            linkedDoor.SetLock(true);
        }

        // Disable the UI canvas initially
        itemImage.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Check if the player is in range and presses the "E" key
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            CollectKeyCard();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if it's the Player colliding with the keycard
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
            player = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if it's the Player exiting the collision
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
            player = null;
        }
    }

    private void CollectKeyCard()
    {
        // Tell the door to unlock itself.
        linkedDoor.SetLock(false);

        // Show the UI image for the key card based on its tag
        if (gameObject.tag == "05")
        {
            itemImage.gameObject.SetActive(true);
            has05 = true;
        }
        else if (gameObject.tag == "01")
        {
            itemImage.gameObject.SetActive(true);
            has01 = true;
        }
        else if (gameObject.tag == "cr")
        {
            itemImage.gameObject.SetActive(true);
            hasCr = true;
        }
        else if (gameObject.tag == "L")
        {
            itemImage.gameObject.SetActive(true);
            hasL = true;
        }

        // Destroy the key card object
        Destroy(gameObject);
    }
}