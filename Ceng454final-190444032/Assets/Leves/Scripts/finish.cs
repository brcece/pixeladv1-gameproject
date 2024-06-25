using UnityEngine;

public class finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (CoinScore.coinAmount >= 100)
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
