using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text playerNameInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        SavePlayerName();

        GameManager.Instance.StartGame();
    }

    public void SavePlayerName() {
        if (playerNameInput == null) return;

        GameManager.Instance.currentPlayerName = playerNameInput.text.Trim();
    }
}
