using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text    scoreText;
    [SerializeField]
    private TMP_Text    highScoreText;
    [SerializeField]
    private Counter     scoreCounter;

    private float       highScore;

    public void SetHighScoreText(string playerName, float score) {
        if (highScoreText == null) return;

        highScoreText.text = playerName + ": " + score.ToString("F1") + "s";
    }

    public void SetScoreText(string playerName, float score) {
        if (scoreText == null) return;

        scoreText.text = playerName + ": " + score.ToString("F1") + "s";
    }

    public void MarkTextAsNewHighScore() {
        if (highScoreText == null) return;

        highScoreText.text  = "New high score!";
        highScoreText.color = Color.yellow;
    }

    public void ExitGame() {
        GameManager.Instance.LoadMainMenu();
    }

    public void ShowScore() {
        float   score               = 0f;
        float   highScore           = 0f;
        bool    newHighScore        = false;
        string  playerName          = GameManager.DEFAULT_PLAYER_NAME;
        string  highScorePlayerName = GameManager.DEFAULT_PLAYER_NAME;

        if (scoreCounter != null) {
            score = scoreCounter.GetScore();
        }
        if(GameManager.Instance != null) {
            highScore           = GameManager.Instance.highScore;
            playerName          = GameManager.Instance.GetCurrentPlayerName();
            highScorePlayerName = GameManager.Instance.GetHighScorePlayerName();
            newHighScore        = score > highScore;

            if (newHighScore) { 
                GameManager.Instance.highScore              = score;
                GameManager.Instance.highScorePlayerName    = playerName;
            }

            GameManager.Instance.SaveGameData();
        }

        SetScoreText(playerName, score);
        if (newHighScore)
            MarkTextAsNewHighScore();
        else 
            SetHighScoreText(highScorePlayerName, highScore);

        gameObject.SetActive(true);
    }

    private void SaveHighScore() {
        if (GameManager.Instance == null) return;

        SetHighScoreText(GameManager.Instance.highScorePlayerName, GameManager.Instance.highScore);
    }
}
