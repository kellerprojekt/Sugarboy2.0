using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameObject spawner;

    private bool destroyClones = false;
    public bool checkPointReached = false;
    public bool resetList = false;

    // Start is called before the first frame update
    private void Start()
    {
        spawner = GameObject.Find("SpawnPoint");
    }

    private void Update()
    {
        DeleteOldClones();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !checkPointReached)
        {
            //when you hit checkpoint, reset available clones
            GameManager.Instance.ResetAllowedClones();
            //set the new spawner position to checkpoint
            spawner.transform.position = this.transform.position;
            destroyClones = true;
            checkPointReached = true;
        }
    }

    private void DeleteOldClones()
    {
        if (!destroyClones)
        {
            return;
        }
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");
        for (int i = 0; i < clones.Length; i++)
        {
            Destroy(clones[i]);
        }
        destroyClones = false;
    }
}