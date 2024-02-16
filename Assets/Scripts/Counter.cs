using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float               currentTime;
    [SerializeField]
    private PlayerController    playerController;
    [SerializeField]
    private TMP_Text            scoreText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
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

        scoreText.text = "Time: " + currentTime.ToString("F1");
    }

    public float GetScore() {
        return currentTime;
    }
}
