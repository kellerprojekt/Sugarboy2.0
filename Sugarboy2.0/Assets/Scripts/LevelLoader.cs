using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    private Text messageText;

    private void Awake()
    {
        messageText = transform.Find("Transition").Find("Image").Find("messageText").GetComponent<Text>();
    }

    private void Start()
    {
        TextWriter.AddWriter_Static(messageText, "Tutorial 1", .1f, true);
    }

}
