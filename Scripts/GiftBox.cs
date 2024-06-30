
/*
 * Author: Verlaine Ong
 * Date: 17/6/2024
 * Description: 
 * Transform objects
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GiftBox : MonoBehaviour
{
    [SerializeField]
    private AudioSource openAudio;

    [SerializeField]
    private GameObject collectibleToSpawn;

    private int sceneToLoad = 7; // The build index of the scene to load

    private Renderer giftBoxRenderer;

    /// <summary>
    /// Function to not show the canvas at the start
    /// </summary>
    private void Start()
    {
        openAudio = GetComponent<AudioSource>();
        giftBoxRenderer = GetComponent<Renderer>();
    }

    /// <summary>
    /// Function for checking if the player touch it and if all items are collected.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (RepairItems.hasAll)
            {
                if (openAudio != null)
                {
                    openAudio.Play();
                }
                SpawnCollectible();
                MakeInvisible();
                StartCoroutine(ChangeSceneAfterDelay(20f));
            }
        }
    }

    /// <summary>
    /// Function to spawn the new collectible
    /// </summary>
    private void SpawnCollectible()
    {
        Instantiate(collectibleToSpawn, transform.position, collectibleToSpawn.transform.rotation);
    }

    /// <summary>
    /// Function to make the gift box invisible
    /// </summary>
    private void MakeInvisible()
    {
        if (giftBoxRenderer != null)
        {
            giftBoxRenderer.enabled = false;
        }
    }

    /// <summary>
    /// Coroutine to change the scene after a delay
    /// </summary>
    /// <param name="delay">Delay in seconds before changing the scene</param>
    /// <returns></returns>
    private IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneToLoad);
    }
}