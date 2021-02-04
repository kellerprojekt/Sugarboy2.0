using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ActivateLaserDoor : MonoBehaviour
{
    [SerializeField] private Text[] text = new Text[2];

    [SerializeField] private GameObject[] doors = new GameObject[2];

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Player"))
        {
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].SetActive(false);
                text[i].text = "open";
                text[i].color = Color.green;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Player"))
        {
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].SetActive(true);
                text[i].text = "closed";
                text[i].color = Color.red;
            }
        }
    }
}