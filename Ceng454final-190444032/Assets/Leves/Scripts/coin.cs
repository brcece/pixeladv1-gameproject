using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    //[SerializeField] private int coinm;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //CoinScore.coinAmount += coinm;
        CoinScore.coinAmount += 20;
        Destroy (gameObject);
    }
}
