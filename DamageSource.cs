
/*
 * Author: Verlaine Ong
 * Date: 17/6/2024
 * Description: 
 * damage function
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    /// <summary>
    /// bool for damage taking
    /// </summary>
    private bool _isCausingDamage = false;

    /// <summary>
    /// damage over time
    /// </summary>

    public float DamageRepeatRate = 0.1f;
    /// <summary>
    /// 1hp per tick
    /// </summary>
    public int DamageAmount = 1;
    /// <summary>
    /// repeating damage
    /// </summary>
    public bool Repeating = true;


    /// <summary>
    /// function to take damage when the player collide with it
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        _isCausingDamage = true;
        Player player = other.gameObject.GetComponent<Player>();
       
        if(player != null )
        {
            if (Repeating)
            {
                //repeating damage
                StartCoroutine(TakeDamage(player, DamageRepeatRate));

            }

            else
            {
                //just one time damage
                player.TakeDamage(DamageAmount);
            }
        }
    }
    /// <summary>
    /// function to take damage over time
    /// </summary>
    /// <param name="player"></param>
    /// <param name="repeatRate"></param>
    /// <returns></returns>
    IEnumerator TakeDamage(Player player, float repeatRate)
    {
        while (_isCausingDamage)
        {
            player.TakeDamage(DamageAmount);
            TakeDamage(player, repeatRate);
            yield return new WaitForSeconds(repeatRate);

        }
    }

    /// <summary>
    /// function to stop taking damage when player exit
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            _isCausingDamage = false;

        }
    }
}
