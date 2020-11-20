using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFindPlayer : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private GameObject currentPlayer;

    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    private void Update()
    {
        currentPlayer = GameObject.FindWithTag("Player");
        cinemachineVirtualCamera.Follow = currentPlayer.transform;
        cinemachineVirtualCamera.LookAt = currentPlayer.transform;
    }
}