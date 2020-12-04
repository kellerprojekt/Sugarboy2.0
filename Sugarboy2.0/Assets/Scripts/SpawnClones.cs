using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClones : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private List<GameObject> clones;

    private GameObject startingSpawnPoint;

    private void Start()
    {
        clones = new List<GameObject>();
        startingSpawnPoint = GameObject.Find("SpawnPoint");
        Instantiate(player, startingSpawnPoint.transform.position, Quaternion.identity);
    }

    private void Update()
    {
        startingSpawnPoint = GameObject.Find("SpawnPoint");
        SpawnClone();
    }

    private void SpawnClone()
    {
        if (Input.GetKeyDown(KeyCode.Q) && GameManager.Instance.AllowedClones > 0)
        {
            GameObject cloneToBe = GameObject.FindWithTag("Player");
            cloneToBe.tag = "Clone";
            clones.Add(cloneToBe);
            GameManager.Instance.ReduceAllowedClones();
            Instantiate(player, startingSpawnPoint.transform.position, Quaternion.identity);
            //instance.tag = "Player";
        }
    }
}