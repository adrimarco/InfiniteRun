using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public const string DEFAULT_PLAYER_NAME = "Anonymous";
    // Singleton instance
    public static GameManager Instance { get; private set; }

    // Score
    public string  highScorePlayerName = "";
    public float   highScore           = 0;
    public string  currentPlayerName   = "";

    private void Awake() {
        if(Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene(0);
    }
}
