using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float               currentTime;
    private float               highScore;
    [SerializeField]
    private PlayerController    playerController;
    [SerializeField]
    private TMP_Text            scoreText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        if (GameManager.Instance)
            highScore = GameManager.Instance.highScore;
        else
            highScore = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController != null && !playerController.gameOver) {
            currentTime += Time.deltaTime;

            UpdateTimeDisplay();
        }
    }

    private void UpdateTimeDisplay() {
        if (scoreText == null) return;

        scoreText.text = "Time: " + currentTime.ToString("F1") + "s";

        if(highScore > 0 && currentTime > highScore) 
            scoreText.color = Color.yellow;
    }

    public float GetScore() {
        return currentTime;
    }
}
