using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricSound : MonoBehaviour
{
    public AudioSource[] clip = new AudioSource[3];
    [SerializeField] private float timeBetween;
    [Range(0, 1)] [SerializeField] private float volume;

    private void Start()
    {
        InvokeRepeating("RepeatSound", 1f, timeBetween);
    }

    private int PlayRandomSound()
    {
        int numb = Random.Range(0, 3);
        return numb;
    }

    private void RepeatSound()
    {
        clip[PlayRandomSound()].Play();
    }
}