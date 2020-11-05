using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] private float _jumpingSpeed = 5f;
    [SerializeField] public bool _isGrounded = false;

    private void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * _movementSpeed;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector2(0f, _jumpingSpeed), ForceMode.Impulse);
        }
    }
}