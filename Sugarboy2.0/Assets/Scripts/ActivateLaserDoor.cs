using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ActivateLaserDoor : MonoBehaviour
{
    [SerializeField] private Text[] text = new Text[2];

    [SerializeField] private GameObject[] doors = new GameObject[2];
    [SerializeField] private Material openDoor;
    [SerializeField] private Material closedDoor;
    [SerializeField] private GameObject[] lights = new GameObject[4];

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
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].GetComponent<Renderer>().material = openDoor;
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
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].GetComponent<Renderer>().material = closedDoor;
            }
        }
    }
}