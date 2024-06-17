using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftBox : MonoBehaviour
{
    [SerializeField]
    private AudioSource openAudio;

    [SerializeField]
    private GameObject collectibleToSpawn;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Collectible.hasCrystal && Collectible.hasMaterial && Collectible.hasEngine)
            {
                openAudio.Play();
                SpawnCollectible();
                Destroy(gameObject);
            }
        }
    }

    void SpawnCollectible()
    {
        Instantiate(collectibleToSpawn, transform.position, collectibleToSpawn.transform.rotation);
    }
}