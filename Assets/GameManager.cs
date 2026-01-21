using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public GameObject gameOverText;

    
    void Awake()
    {
        Time.timeScale = 1;
        singleton = this;
        gameOverText.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverText.SetActive(true);
        StartCoroutine(ResetScene());
    }

    public IEnumerator ResetScene()
    {
        yield return new WaitForSecondsRealtime(3);
        Debug.Log("RESET SCENE");
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
