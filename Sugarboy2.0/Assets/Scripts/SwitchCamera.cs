using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    [SerializeField] private int priority;

    private void Awake () {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera> ();
    }

    private void Update () {
        if (GameManager.Instance.priority == priority) {
            cinemachineVirtualCamera.Priority = GameManager.Instance.priority;
        } else {
            cinemachineVirtualCamera.Priority = -10;
        }
    }
}