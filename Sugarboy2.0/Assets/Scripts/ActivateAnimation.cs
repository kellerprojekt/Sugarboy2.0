using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnimation : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private GameObject elevator;

    private AudioSource audioSource;
    [SerializeField] private bool contact = false;

    private void Awake()
    {
        anim = elevator.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    private void Update()
    {
        if (contact)
        {
            anim.SetBool("activated", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Player"))
        {
            contact = true;

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
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}