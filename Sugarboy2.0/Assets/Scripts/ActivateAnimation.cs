using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnimation : MonoBehaviour
{
    private Animator anim;

    //private bool activated = false;
    [SerializeField] private GameObject elevator;

    private void Awake()
    {
        anim = elevator.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Player"))
        {
            if (anim.enabled == false)
            {
                anim.enabled = true;
            }
            anim.SetBool("activated", true);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            anim.enabled = false;
            anim.SetBool("activated", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            if (anim.enabled == false)
            {
                anim.enabled = true;
            }
            anim.SetBool("activated", true);
        }
    }
}