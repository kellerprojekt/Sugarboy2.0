using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrounded : MonoBehaviour {
    private GameObject Player;

    // Start is called before the first frame update
    private void Start () {
        Player = gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter (Collider other) {
        if (other.CompareTag ("Ground")) {
            Player.GetComponent<PlayerMovement> ()._isGrounded = true;
        }
    }

    private void OnTriggerExit (Collider other) {
        if (other.CompareTag ("Ground")) {
            Player.GetComponent<PlayerMovement> ()._isGrounded = false;
        }
    }
}