﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int AllowedClones { get; private set; }
    public int AllowedClonesReset { get; private set; }
    public GameObject activePlayer;
    public int counter;
    private List<GameObject> clones;
    private static GameManager _instance;

    public static GameManager Instance {
        get {
            if (_instance == null) {
                GameObject go = new GameObject ("GameManager");
                go.AddComponent<GameManager> ();
            }
            return _instance;
        }
    }

    private void Awake () {
        _instance = this;
    }

    private void Start () {
        counter = 0;
        AllowedClones = 3;
        AllowedClonesReset = AllowedClones;
        activePlayer = GameObject.FindGameObjectWithTag ("Player");
        clones = new List<GameObject> ();
    }

    public void ReduceAllowedClones () {
        if (AllowedClones > 0) {
            AllowedClones--;
        }
    }

    public void ResetAllowedClones () {
        AllowedClones = AllowedClonesReset;
    }

    public void ClearList () {
        for (int i = 0; i < clones.Count; i++) {
            Destroy (clones[i]);
        }
        clones.Clear ();
    }
    public void AddCloneToList (GameObject clone) {
        clones.Add (clone);
        Debug.Log ("Clone Added : " + clone.tag);
    }
}