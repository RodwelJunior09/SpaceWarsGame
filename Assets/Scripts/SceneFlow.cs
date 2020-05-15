using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlow : MonoBehaviour
{
    GameStatus gameStatus;

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        gameStatus = FindObjectOfType<GameStatus>();
        gameStatus.ResetGame();
    }

    public void LoadNextScene()
    {
        int currentIndexScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndexScene + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
