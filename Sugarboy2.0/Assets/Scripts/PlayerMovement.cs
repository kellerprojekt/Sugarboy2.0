using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] public bool _isGrounded = false;
    [SerializeField] private float _jumpingSpeed = 5f;
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private float maxDistance = 1.5f;
    RaycastHit hit;
    private Vector3 direction;
    [SerializeField] private bool hitDetected;
    private BoxCollider boxCollider;
    Rigidbody rb;

    private void Awake () {
        boxCollider = gameObject.GetComponent<BoxCollider> ();
        rb = this.GetComponent<Rigidbody> ();
    }
    private void FixedUpdate () {
        //Both ways of movement do basically the same thing. I have no idea why the movement occasionally becomes jittery or by moving against some other object too. TODO -> need to figure out why that happens

        transform.Translate (Vector3.Normalize (Vector3.right) * _movementSpeed * Time.deltaTime * Input.GetAxis ("Horizontal"));

        // rb.MovePosition ((transform.position + (direction * _movementSpeed * Time.deltaTime)));
    }

    private void Update () {
        direction = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, 0);
        Jump ();
    }
    private void Jump () {
        if (IsGrounded () && Input.GetButtonDown ("Jump")) {
            gameObject.GetComponent<Rigidbody> ().AddForce (new Vector2 (0f, _jumpingSpeed), ForceMode.Impulse);
        }
    }

    private bool IsGrounded () {

        hitDetected = Physics.BoxCast (new Vector3 (transform.position.x, transform.position.y, transform.position.z),
            new Vector3 ((boxCollider.size.x * 0.9f), boxCollider.size.y, (boxCollider.size.z * 0.9f)) * 0.5f, -Vector3.up,
            out hit,
            boxCollider.transform.rotation,
            maxDistance
        );

        return hitDetected;
    }

}