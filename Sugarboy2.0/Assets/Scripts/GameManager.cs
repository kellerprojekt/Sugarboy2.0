using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int AllowedClones { get; private set; }
    public int AllowedClonesReset { get; private set; }
    public GameObject activePlayer;
    public int counter;
    private List<GameObject> clones;
    private static GameManager _instance;
    public int priority;
    public bool recording;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        counter = 0;
        AllowedClones = 3;
        AllowedClonesReset = AllowedClones;
        activePlayer = GameObject.FindGameObjectWithTag("Player");
        clones = new List<GameObject>();

        priority = 0;
        recording = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IncreasePriority(10);
        }
    }

    public void ReduceAllowedClones()
    {
        if (AllowedClones > 0)
        {
            AllowedClones--;
        }
    }

    public void ResetAllowedClones()
    {
        AllowedClones = AllowedClonesReset;
    }

    public void ClearList()
    {
        for (int i = 0; i < clones.Count; i++)
        {
            Destroy(clones[i]);
        }
        clones.Clear();
    }

    public void AddCloneToList(GameObject clone)
    {
        clones.Add(clone);
    }

    public void IncreasePriority(int inc)
    {
        priority += inc;
        if (priority == 30)
        {
            priority = 0;
        }
    }
}