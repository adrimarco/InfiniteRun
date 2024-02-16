using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    float obstacleInterval = 1.5f;
    float obstacleStart = 3.0f;
    Vector3 spawnPosition = new Vector3(30.0f, 0.0f, 0.0f);
    static PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", obstacleStart, obstacleInterval);
        if (!playerControllerScript) {
            playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacle() {
        if (!playerControllerScript.gameOver)
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }
}
