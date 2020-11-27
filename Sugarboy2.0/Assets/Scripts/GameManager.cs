using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int AllowedClones { get; private set; }
    public int AllowedClonesReset { get; private set; }
    private static GameManager _instance;

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
        AllowedClones = 3;
        AllowedClonesReset = AllowedClones;
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
}