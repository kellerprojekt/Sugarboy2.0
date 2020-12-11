using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] public bool _isGrounded = false;
    [SerializeField] private float _jumpingSpeed = 5f;
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private float maxDistance = 1.5f;
    [SerializeField] private bool hitDetected;
    private BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.activePlayer.CompareTag(this.tag))
        {
            Movement();
        }
    }

    private void Movement()
    {
        transform.Translate(Vector3.Normalize(Vector3.right) * _movementSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }

    private void Update()
    {
        if (GameManager.Instance.activePlayer.CompareTag(this.tag))
        {
            Jump();
        }
    }

    //private bool CheckActive()
    //{
    //    return this.CompareTag("Player");
    //}

    private void Jump()
    {
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector2(0f, _jumpingSpeed), ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        hitDetected = Physics.BoxCast(new Vector3(transform.position.x, transform.position.y, transform.position.z),
                new Vector3((boxCollider.size.x * 0.9f), boxCollider.size.y, (boxCollider.size.z * 0.9f)) * 0.5f, -Vector3.up,
                out _,
                boxCollider.transform.rotation,
                maxDistance
            );

        return hitDetected;
    }
}