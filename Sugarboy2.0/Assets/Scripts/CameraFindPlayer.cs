using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFindPlayer : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] private GameObject currentPlayer;

    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    private void Update()
    {
        currentPlayer = GameManager.Instance.activePlayer;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentPlayer = GameManager.Instance.activePlayer;
        }

        cinemachineVirtualCamera.Follow = currentPlayer.transform;
        cinemachineVirtualCamera.LookAt = currentPlayer.transform;
    }
}