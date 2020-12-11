using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCloneNoRewind : MonoBehaviour
{
    private List<GameObject> clones;
    [SerializeField] private GameObject clone;

    private Transform spawningPosition;

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
        if (Input.GetKeyDown(KeyCode.Q) && GameManager.Instance.AllowedClones > 0)
        {
            spawningPosition = GameObject.FindGameObjectWithTag("Player_" + GameManager.Instance.counter).transform;
            GameManager.Instance.counter++;
            GameManager.Instance.ReduceAllowedClones();
            GameObject obj = Instantiate(clone, spawningPosition.position, Quaternion.identity);
            obj.tag = "Player_" + GameManager.Instance.counter;
            GameManager.Instance.activePlayer = obj;
            clones.Add(obj);
        }
    }
}