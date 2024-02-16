using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private const float         MIN_SPAWN_TIME  = 0.8f;
    private const float         MAX_SPAWN_TIME  = 1.4f;

    [SerializeField]
    private GameObject          obstaclePrefab;
    [SerializeField]
    private PlayerController    playerControllerScript;
    [SerializeField]
    private Vector3             spawnPosition           = new Vector3(30.0f, 0.0f, 0.0f);

    private float               remainingSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        remainingSpawnTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        remainingSpawnTime -= Time.deltaTime;

        if(remainingSpawnTime <= 0f) {
            SpawnObstacle();

            remainingSpawnTime = Random.Range(MIN_SPAWN_TIME, MAX_SPAWN_TIME);
        }
    }

    private void SpawnObstacle() {
        if (!playerControllerScript.gameOver)
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }
}
