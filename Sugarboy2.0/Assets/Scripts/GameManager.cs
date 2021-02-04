using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int AllowedClones { get; private set; }
    public int AllowedClonesReset { get; private set; }

    [Header("How many clones should spawn")]
    [SerializeField] private int cloneAmout;

    public GameObject activePlayer;
    public int counter;
    private List<GameObject> clones;
    private static GameManager _instance;
    public int priority;
    public bool recording;
    private PlayerControls controls;
    public int priorityIncrement;

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
        controls = new PlayerControls();
        controls.Gameplay.SwitchCamera.performed += _ => IncreasePriority();
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    private void Start()
    {
        counter = 0;
        AllowedClones = cloneAmout;
        AllowedClonesReset = AllowedClones;
        activePlayer = GameObject.FindGameObjectWithTag("Player");
        clones = new List<GameObject>();

        priority = 0;
        recording = false;
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

    //Will not be used, Deleting is stupid anyway
    public void ClearList()
    {
        for (int i = 0; i < clones.Count; i++)
        {
            clones[i].SetActive(false);
        }
        clones.Clear();
    }

    public void AddCloneToList(GameObject clone)
    {
        clones.Add(clone);
    }

    public void IncreasePriority()
    {
        priority += priorityIncrement;
        if (priority == 30)
        {
            priority = 0;
        }
    }
}