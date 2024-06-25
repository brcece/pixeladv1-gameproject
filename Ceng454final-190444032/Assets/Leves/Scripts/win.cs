using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (CoinScore.coinAmount >= 1000)
            {
                SceneController.instance.NextLevel();
            }
            else
            {
                Debug.Log("Not enough coins to proceed to the next level!");
            }
        }
    }
}
