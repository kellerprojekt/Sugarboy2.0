using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    //private bool switchedCamera = false;
    //private readonly int priority = 20;
    [SerializeField] private int priority;

    // Start is called before the first frame update
    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.Instance.priority == priority)
        {
            cinemachineVirtualCamera.Priority = GameManager.Instance.priority;
        }
        else
        {
            cinemachineVirtualCamera.Priority = -10;
        }
    }

    //private void ChangePriority()
    //{
    //    if (!switchedCamera)
    //    {
    //        cinemachineVirtualCamera.Priority += priority;
    //        switchedCamera = !switchedCamera;
    //        return;
    //    }
    //    cinemachineVirtualCamera.Priority -= priority;
    //    switchedCamera = !switchedCamera;
    //}
}