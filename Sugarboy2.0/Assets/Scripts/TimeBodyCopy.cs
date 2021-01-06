using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimeBodyCopy : MonoBehaviour {
    [SerializeField] private GameObject clone;

    //private List<GameObject> clones;
    public float recordTime = 5f;

    private List<PointInTime> pointsInTime;
    private Rigidbody rb;
    [SerializeField] private bool switchList = false;
    private List<PointInTime> pointsInTimeCopy;
    private bool listCopied = false;

    private int keyCounter = 0;

    private bool recording = false;
    private Transform spawningPosition;

    private void Start () {
        pointsInTime = new List<PointInTime> ();
        rb = GetComponent<Rigidbody> ();

    }

    private void Update () {
        //Check if current object matches the current active player object
        clone = GameManager.Instance.activePlayer;
        bool currentPlayer = clone.CompareTag (this.tag);
        if (Input.GetKeyDown (KeyCode.G) && !recording && currentPlayer) {
            recording = true;
            keyCounter++;
        } else if (Input.GetKeyDown (KeyCode.G) && recording && currentPlayer) {
            recording = false;
            keyCounter++;
        }
    }

    private void FixedUpdate () {
        //if press button start recoring
        if (recording) {
            Record ();
        }
        if (keyCounter > 2) {
            this.tag = $"Player_{GameManager.Instance.counter}";
            GameManager.Instance.AddCloneToList (this.gameObject);
            Rewind ();
            rb.isKinematic = true;
        }
        if (keyCounter == 2) {
            Clone ();
            keyCounter++;
        }
    }

    private void Rewind () {
        if (!switchList) {
            if (!listCopied) {
                pointsInTimeCopy = new List<PointInTime> (pointsInTime);
                listCopied = true;
            }
            RewindList (pointsInTime);
        } else if (switchList) {
            if (listCopied) {
                pointsInTime = new List<PointInTime> (pointsInTimeCopy);
                listCopied = false;
            }
            RewindList (pointsInTimeCopy);
        }
    }

    private void RewindList (List<PointInTime> list) {
        if (list.Count > 0) {
            PointInTime pointInTime = list[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            list.RemoveAt (0);
        } else {
            rb.isKinematic = false;
            switchList = !switchList;
        }
    }

    private void Record () {
        pointsInTime.Add (new PointInTime (transform.position, transform.rotation));
    }

    public void ResetList () {
        pointsInTime.Clear ();
    }

    //Instantiate a new player at the position of the current one and give controle to the new player object
    private void Clone () {
        spawningPosition = GameManager.Instance.activePlayer.transform;
        GameManager.Instance.ReduceAllowedClones ();
        GameObject obj = Instantiate (clone, spawningPosition.position, Quaternion.identity);
        obj.tag = "Player";
        GameManager.Instance.activePlayer = obj;
    }
}