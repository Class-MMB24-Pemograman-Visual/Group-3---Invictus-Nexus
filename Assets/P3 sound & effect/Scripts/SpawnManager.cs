using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void Update()
    {
        if (playerControllerScript.gameOver)
        {
            CancelInvoke("SpawnObstacle");
        }
    }

    void SpawnObstacle()
    {
        if (playerControllerScript != null && !playerControllerScript.gameOver)
        {
            if (obstaclePrefabs != null)
            {
                Instantiate(obstaclePrefabs, spawnPos, obstaclePrefabs.transform.rotation);
            }
            else
            {
                Debug.LogWarning("Obstacle Prefab hilang! Pastikan prefab dihubungkan di Inspector.");
            }
        }
    }
}
