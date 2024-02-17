using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetPlayerName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Instance && GameManager.Instance.currentPlayerName.Length > 1) {
            TMP_InputField inputField;
            if(gameObject.TryGetComponent<TMP_InputField>(out inputField)) {
                inputField.text = GameManager.Instance.currentPlayerName;
            }
        }
    }
}
