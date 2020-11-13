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
    [SerializeField] private bool hitDetected;
    private BoxCollider boxCollider;

    private void Awake () {
        boxCollider = gameObject.GetComponent<BoxCollider> ();
    }
    private void FixedUpdate () {
        transform.Translate (Vector3.Normalize (Vector3.right) * _movementSpeed * Time.deltaTime * Input.GetAxis ("Horizontal"));
    }
    private void Update () {
        Jump ();
    }
    private void Jump () {
        if (IsGrounded () && Input.GetButtonDown ("Jump")) {
            gameObject.GetComponent<Rigidbody> ().AddForce (new Vector2 (0f, _jumpingSpeed), ForceMode.Impulse);
        }
    }

    // private bool checkGround(){
    //     bool grounded = Physics.OverlapBox(transform.position / 2, transform.lossyScale / 2, Quaternion.identity, platformLayerMask);
    // }

    private bool IsGrounded () {

        hitDetected = Physics.BoxCast (new Vector3 (transform.position.x, transform.position.y, transform.position.z),
            new Vector3 ((boxCollider.size.x * 0.9f), boxCollider.size.y, (boxCollider.size.z * 0.9f)) * 0.5f, -Vector3.up,
            out hit,
            boxCollider.transform.rotation,
            maxDistance
        );

        // Debug.Log (hitDetected);

        return hitDetected;
    }

}