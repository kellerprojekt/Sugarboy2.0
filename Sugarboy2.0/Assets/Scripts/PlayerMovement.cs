using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] public bool _isGrounded = false;
    [SerializeField] private float _jumpingSpeed = 5f;
    private void FixedUpdate () {
        transform.Translate (Vector3.Normalize (Vector3.right) * _movementSpeed * Time.deltaTime * Input.GetAxis ("Horizontal"));
    }
    private void Update () {
        Jump ();
    }
    private void Jump () {
        if (Input.GetButtonDown ("Jump") && _isGrounded == true) {
            gameObject.GetComponent<Rigidbody> ().AddForce (new Vector2 (0f, _jumpingSpeed), ForceMode.Impulse);
        }
    }
}