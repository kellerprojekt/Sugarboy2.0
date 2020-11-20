using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject clone;
    [SerializeField] private GameObject startingSpawnPoint;

    private void Start()
    {
        Instantiate(player, startingSpawnPoint.transform.position, Quaternion.identity);
    }

    private void Update()
    {
        SpawnClone();
    }

    private void SpawnClone()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject instance = Instantiate(player, startingSpawnPoint.transform.position, Quaternion.identity);
            instance.tag = "Player";
        }
    }
}