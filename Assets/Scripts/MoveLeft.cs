using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    float speed = 20.0f;
    float leftLimit = -15.0f;
    static PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        if (!playerControllerScript) {
            playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        
        if (transform.position.x < leftLimit && gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
    }
}
