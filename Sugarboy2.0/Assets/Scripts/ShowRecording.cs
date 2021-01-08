using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRecording : MonoBehaviour
{
    [SerializeField] private Text recordingText;

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.Instance.recording)
        {
            recordingText.text = "Recording...";
        }
        else
        {
            recordingText.text = "";
        }
    }
}