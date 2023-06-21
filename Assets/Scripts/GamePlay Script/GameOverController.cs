using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private Canvas gameOverCanvas;

    [SerializeField]
    private Text currentScore, bestScore;

    private ScoreCounter scoreCounter;


    private void Start()
    {
        scoreCounter = GetComponent<ScoreCounter>();
    }


    public void GameOverShowPanel()
    {
        //scoreCounter.CanCountScore = false;
        Time.timeScale = 0f;

        gameOverCanvas.enabled = true;

        DisplayScore();

        CheckToUnlockNewCharacters(scoreCounter.GetScore());
    }

    void DisplayScore()
    {
        currentScore.text = "Score: " + scoreCounter.GetScore() + "m";
    }


    void CheckToUnlockNewCharacters(int score)
    {

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(TagManager.GAMEPLAY_SCENE_NAME);
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(TagManager.MAIN_MENU_SCENE_NAME);
    }


}
