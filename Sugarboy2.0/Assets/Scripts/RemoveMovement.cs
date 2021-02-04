using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMovement : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerMovement>().enabled = false;
    }
}