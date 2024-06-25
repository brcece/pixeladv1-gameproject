using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void NextLevel()
    {
        CoinScore.coinAmount = 0;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);  
    }

}
