using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text    scoreText;
    [SerializeField]
    private TMP_Text    highScoreText;

    private float       highScore;

    public void SetHighScoreText(string playerNamer, float score) {
        if (highScoreText == null) return;

        highScoreText.text = playerNamer + ": " + score.ToString("F1");
    }

    public void SetScoreText(string playerNamer, float score) {
        if (scoreText == null) return;

        scoreText.text = playerNamer + ": " + score.ToString("F1");
    }

    public void ExitGame() {
        GameManager.Instance.LoadMainMenu();
    }

    public void Show() {
        gameObject.SetActive(true);
    }
}
