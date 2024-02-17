using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InitHud : MonoBehaviour
{
    [SerializeField]
    private TMP_Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (highScoreText == null || GameManager.Instance == null) return;

        if (GameManager.Instance.highScore > 0)
            highScoreText.text = GameManager.Instance.GetHighScorePlayerName() + ": " + GameManager.Instance.highScore.ToString("F1") + "s";
        else
            highScoreText.text = "--";
    }
}
