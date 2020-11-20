using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    [SerializeField] private bool isRewinding = false;

    //time for how long to record
    public float recordTime = 5f;

    private List<PointInTime> pointsInTime;
    private List<PointInTime> repeatingPositions;
    private bool listCopied = false;
    private bool switchList = false;

    private Rigidbody rb;

    private void Start()
    {
        pointsInTime = new List<PointInTime>();
        repeatingPositions = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            StartRewind();
        }
    }

    private void FixedUpdate()
    {
        if (!isRewinding && !switchList)
        {
            Record();
        }
        else
        {
            Rewind();
        }
    }

    //TODO copied list is not working -> idea -> copy list of original and replay values of that one
    private void Rewind()
    {
        switch (switchList)
        {
            case true:
                PointInTime repeationgPosition = repeatingPositions[0];
                //set positions from saved positions
                transform.position = repeationgPosition.position;
                transform.rotation = repeationgPosition.rotation;
                //rb.MovePosition(pointInTime.position);

                break;

            case false:
                if (pointsInTime.Count > 0 && !listCopied)
                {
                    repeatingPositions = pointsInTime.ToList();
                    listCopied = true;
                }
                else if (pointsInTime.Count > 0)
                {
                    PointInTime pointInTime = pointsInTime[0];
                    //set positions from saved positions
                    transform.position = pointInTime.position;
                    transform.rotation = pointInTime.rotation;
                    // rb.MovePosition (pointInTime.position);
                    //remove from list
                    pointsInTime.RemoveAt(0);
                }
                else
                {
                    switchList = true;
                    StopRewind();
                }
                break;

            default:
                return;
        }
    }

    private void Record()
    {
        //check if there are more positions in list than time has passed
        if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            //remove last position added
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }
        //else add new positions
        pointsInTime.Add(new PointInTime(transform.position, transform.rotation));
    }

    private void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    private void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }
}