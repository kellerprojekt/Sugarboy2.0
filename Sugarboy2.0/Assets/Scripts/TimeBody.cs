using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour {
    [SerializeField] private bool isRewinding = false;

    //time for how long to record
    public float recordTime = 5f;

    List<PointInTime> pointsInTime;

    Rigidbody rb;

    // Use this for initialization
    void Start () {
        pointsInTime = new List<PointInTime> ();
        rb = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey (KeyCode.Q)) {
            StartRewind ();
            Rewind ();
        }
    }

    private void CheckKey () {

    }

    void FixedUpdate () {
        if (!isRewinding) {
            Record ();
        }
    }

    void Rewind () {
        //Check if there are positions in List
        if (pointsInTime.Count > 0) {
            PointInTime pointInTime = pointsInTime[0];
            //set positions from saved positions
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            // rb.MovePosition (pointInTime.position);
            //remove from list
            pointsInTime.RemoveAt (0);
        } else {
            StopRewind ();
        }

    }

    void Record () {
        //check if there are more positions in list than time has passed 
        if (pointsInTime.Count > Mathf.Round (recordTime / Time.fixedDeltaTime)) {
            //remove last position added
            pointsInTime.RemoveAt (pointsInTime.Count - 1);
        }
        //else add new positions
        pointsInTime.Add (new PointInTime (transform.position, transform.rotation));
    }

    public void StartRewind () {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind () {
        isRewinding = false;
        rb.isKinematic = false;
    }

}