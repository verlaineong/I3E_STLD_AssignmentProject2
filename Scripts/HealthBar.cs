
/*
 * Author: Verlaine Ong
 * Date: 20/06/2024
 * Description: 
 * Contains functions related to health
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image ImgHealthBar;
    public TextMeshProUGUI healthTxt;

    /// <summary>
    /// int for min health
    /// </summary>
    public int Min;
    /// <summary>
    /// int for max health
    /// </summary>
    public int Max;

    private int mCurrentValue;
    private float mCurrentPercent;

    /// <summary>
    /// function for health 
    /// </summary>
    /// <param name="health"></param>
    public void SetHealth(int health)
    {
        if (health != mCurrentValue)
        {
            if (Max - Min == 0)
            {
                mCurrentValue = 0;
                mCurrentPercent = 0;
            }
            else
            {
                mCurrentValue = health;
                mCurrentPercent = (float)mCurrentValue / (float)(Max - Min);
            }

            healthTxt.text = string.Format("Health: {0}%", Mathf.RoundToInt(mCurrentPercent * 100));
            ImgHealthBar.fillAmount = mCurrentPercent;
        }
    }

    /// <summary>
    /// function to return percentage of health
    /// </summary>
    public float CurrentPercent
    {
        get { return mCurrentPercent; }
    }

    /// <summary>
    /// function to return value of health
    /// </summary>
    public int CurrentValue
    {
        get { return mCurrentValue; }
    }


    ///private void Start() 
    /// <summary>
    /// private void Start() 
    /// </summary>h(41);
}