using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    [SerializeField] private bool isRewinding = false;

    public float recordTime = 5f;

    private List<PointInTime> pointsInTime;
    private Rigidbody rb;
    [SerializeField] private bool recordedOnce = false;
    [SerializeField] private bool switchList = false;
    private List<PointInTime> pointsInTimeCopy;
    private bool listCopied = false;

    private void Start()
    {
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && GameManager.Instance.AllowedClones > 0)
        {
            StartRewind();
        }
    }

    private void FixedUpdate()
    {
        if (isRewinding && !recordedOnce)
        {
            Rewind();
        }
        else if (!recordedOnce)
        {
            Record();
        }
        else if (recordedOnce && isRewinding)
        {
            Rewind();
        }
    }

    private void Rewind()
    {
        if (!switchList)
        {
            if (!listCopied)
            {
                pointsInTimeCopy = new List<PointInTime>(pointsInTime);
                listCopied = true;
            }
            RewindList(pointsInTime);
        }
        else if (switchList)
        {
            if (listCopied)
            {
                pointsInTime = new List<PointInTime>(pointsInTimeCopy);
                listCopied = false;
            }
            RewindList(pointsInTimeCopy);
        }
    }

    private void RewindList(List<PointInTime> list)
    {
        if (list.Count > 0)
        {
            PointInTime pointInTime = list[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            list.RemoveAt(0);
        }
        else
        {
            StopRewind();
            switchList = !switchList;
        }
    }

    private void Record()
    {
        if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(0);
        }

        pointsInTime.Add(new PointInTime(transform.position, transform.rotation));
    }

    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
        recordedOnce = true;
    }
}