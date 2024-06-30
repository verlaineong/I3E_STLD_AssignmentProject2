/*
 * Author: Verlaine Ong
 * Date: 26/5/2024
 * Description: 
 * Contains Game manager
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public TextMeshProUGUI scoreText;


    /// <summary>
    /// int to keep score
    /// </summary>
    public int currentScore = 0;

    /// <summary>
    /// function to store objects
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else if (Instance != null && Instance != this)
        {
           Destroy(gameObject);
        }


    }
    /// <summary>
    /// function to add scores
    /// </summary>
    /// <param name="scoreToAdd"></param>
    public void IncreaseScore(int scoreToAdd)
    {
        // Increase the score of the player by scoreToAdd
        currentScore += scoreToAdd;

        scoreText.text = "Score: " + currentScore.ToString();
    }

}
