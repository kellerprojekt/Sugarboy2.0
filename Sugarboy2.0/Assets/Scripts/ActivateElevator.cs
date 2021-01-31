using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateElevator : MonoBehaviour
{
    private Animator anim;
    private bool activated = false;
    [SerializeField] private GameObject elevator;


    private void Awake()
    {
        anim = elevator.GetComponent<Animator>();
        anim.StopPlayback();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (!activated && collision.gameObject.tag.Contains("Player"))
        {
            anim.Play("Elevator_move_up");
            activated = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (activated && other.gameObject.tag.Contains("Player"))
        {
            anim.StopPlayback();
            activated = false;
        }
    }
}
