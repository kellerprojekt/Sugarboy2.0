using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] public bool _isGrounded = false;
    [SerializeField] private float _jumpingSpeed = 5f;
    [SerializeField] private float maxDistance = 1.5f;
    [SerializeField] private bool hitDetected;
    [SerializeField] private BoxCollider boxCollider;
    private RaycastHit hit;

    private PlayerControls controls;

    private float movement;

    private void Awake()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
        controls = new PlayerControls();

        controls.Gameplay.Movement.performed += ctx => movement = ctx.ReadValue<float>();
        controls.Gameplay.Movement.canceled += ctx => movement = 0;
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    private void Start()
    {
        controls.Gameplay.Jump.performed += ctx => Jump();
    }

    private void FixedUpdate()
    {
        //IsGrounded();
        if (GameManager.Instance.activePlayer.CompareTag(gameObject.tag))
        {
            Movement();
        }
    }

    private void Movement()
    {
        transform.Translate(Vector3.Normalize(Vector3.right) * _movementSpeed * Time.deltaTime * movement);
    }

    private void Jump()
    {
        if (GameManager.Instance.activePlayer.CompareTag(gameObject.tag) && _isGrounded)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector2(0f, _jumpingSpeed), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided with : " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    private void IsGrounded()
    {
        //hitDetected = Physics.BoxCast(new Vector3(transform.position.x, transform.position.y, transform.position.z),
        hitDetected = Physics.BoxCast(boxCollider.bounds.center, transform.localScale, -transform.up, out hit, transform.rotation, maxDistance);
        if (hitDetected)
        {
            if (hit.collider.CompareTag("Ground") && !_isGrounded)
            {
                _isGrounded = true;
                return;
            }
        }
        //new Vector3((boxCollider.size.x * 0.9f), boxCollider.size.y, (boxCollider.size.z * 0.9f)) * 0.5f, -Vector3.up,
        //out _,
        //boxCollider.transform.rotation,
        //maxDistance
        //);

        _isGrounded = false;
    }

    private void OnDrawGizmos()
    {
        // Display the explosion radius when selected
        //if (boxCollider != null)
        //{
        //    if (_isGrounded)
        //    {
        //        Gizmos.color = Color.red;
        //        Gizmos.DrawRay(transform.position,-transform.up *maxDistance);
        //        Gizmos.DrawWireCube(transform.position + (-transform.up) * maxDistance, transform.localScale);

        //    }
        //    else
        //    {
        //        Gizmos.DrawRay(transform.position, -transform.up * maxDistance);
        //        Gizmos.DrawWireCube(transform.position + (-transform.up) * maxDistance, transform.localScale);
        //    }
        //}
    }
}