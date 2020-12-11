using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnCloneNoRewind : MonoBehaviour
{
    private List<GameObject> clones;
    [SerializeField] private GameObject clone;
    private Transform spawningPosition;
    private readonly int[] keyNumbers = { 0, 1, 2, 3 };

    // Start is called before the first frame update
    private void Start()
    {
        clone = GameObject.FindGameObjectWithTag("Player_" + GameManager.Instance.counter);
        clones = new List<GameObject>
        {
            clone
        };
    }

    private void Update()
    {
        Clone();
        SelectClone();
    }

    private void Clone()
    {
        if (Input.GetKeyDown(KeyCode.Q) && GameManager.Instance.AllowedClones > 0)
        {
            spawningPosition = GameManager.Instance.activePlayer.transform;
            GameManager.Instance.counter++;
            GameManager.Instance.ReduceAllowedClones();
            GameObject obj = Instantiate(clone, spawningPosition.position, Quaternion.identity);
            obj.tag = "Player_" + GameManager.Instance.counter;
            GameManager.Instance.activePlayer = obj;
            clones.Add(obj);
        }
    }

    //check if clone exists in list to prevent out of bounds exception
    private bool Exists(int position)
    {
        return clones.Any(o => o.CompareTag("Player_" + position));
    }

    private void SelectClone()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Exists(keyNumbers[0]))
        {
            SetSpawnPositionAndActivePlayer(keyNumbers[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && Exists(keyNumbers[1]))
        {
            SetSpawnPositionAndActivePlayer(keyNumbers[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && Exists(keyNumbers[2]))
        {
            SetSpawnPositionAndActivePlayer(keyNumbers[2]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && Exists(keyNumbers[3]))
        {
            SetSpawnPositionAndActivePlayer(keyNumbers[3]);
        }
    }

    private void SetSpawnPositionAndActivePlayer(int position)
    {
        GameManager.Instance.activePlayer = clones[position];
        spawningPosition = clones[position].transform;
    }
}