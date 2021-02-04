using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnimation : MonoBehaviour
{
    private Animator anim;

    //private bool activated = false;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Player"))
        {
            Debug.Log("hello");
            if (anim.enabled == false)
            {
                anim.enabled = true;
            }
            anim.SetBool("activated", true);
        }
        if (collision.gameObject.tag.Contains("_"))
        {
            Debug.Log("hello2");
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