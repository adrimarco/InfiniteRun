using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public const string SAVE_FILE_PATH = "/savefile.json";

    [System.Serializable]
    class SaveData { 
        public string  highScorePlayerName = "";
        public float   highScore           = 0;
        public string  currentPlayerName   = "";
    }

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

        LoadGameData();
    }
    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void SaveGameData() { 
        SaveData save = new SaveData();
        save.highScore              = highScore;
        save.currentPlayerName      = currentPlayerName;
        save.highScorePlayerName    = highScorePlayerName;

        string jsonFile = JsonUtility.ToJson(save);
        File.WriteAllText(Application.persistentDataPath + SAVE_FILE_PATH, jsonFile);
    }

    public void LoadGameData() {
        string savePath = Application.persistentDataPath + SAVE_FILE_PATH;

        if (!File.Exists(savePath)) return; 
        
        string saveAsJson = File.ReadAllText(savePath);
        SaveData saved = JsonUtility.FromJson<SaveData>(saveAsJson);

        currentPlayerName   = saved.currentPlayerName;
        highScore           = saved.highScore;
        highScorePlayerName = saved.highScorePlayerName;
    }
}
