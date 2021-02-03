using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ActivateLaserDoor : MonoBehaviour
{
    [SerializeField] private Text text;
    private PlayerControls controls;
    private readonly Animator[] anim = new Animator[2];
    [SerializeField] private GameObject[] door = new GameObject[2];
    [SerializeField] private float keyPress;
    [SerializeField] private bool playerDetected = false;
    [SerializeField] private bool animationPlaying = false;
    [SerializeField] private int counter = 0;

    private void Awake()
    {
        controls = new PlayerControls();
        for (int i = 0; i < door.Length; i++)
        {
            anim[i] = door[i].GetComponent<Animator>();
        }
        controls.Gameplay.Use.performed += ctx => Activate();
        controls.Gameplay.Use.canceled += ctx => Deactivate();
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    private void Update()
    {
        PlayAnimation();
        ReverseAnimation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerDetected = false;
        }
    }

    private void Activate()
    {
        if (keyPress < 1)
        {
            keyPress = 1;
        }
    }

    private void Deactivate()
    {
        if (keyPress >= 1)
        {
            keyPress = 0;
        }
    }

    private void PlayAnimation()
    {
        if (keyPress >= 1 && playerDetected && !animationPlaying && counter == 0)
        {
            for (int i = 0; i < anim.Length; i++)
            {
                if (anim[i] != null)
                {
                    if (anim[i].enabled == false)
                    {
                        anim[i].enabled = true;
                    }
                }
            }
            for (int i = 0; i < anim.Length; i++)
            {
                if (anim[i] != null)
                {
                    anim[i].SetFloat("direction", 1f);
                    anim[i].SetBool("activated", true);
                }
            }
            animationPlaying = true;
            counter++;
            StartCoroutine(WaitForAnimation());
        }
    }

    private void ReverseAnimation()
    {
        if (keyPress >= 1 && !animationPlaying && counter == 1)
        {
            for (int i = 0; i < anim.Length; i++)
            {
                if (anim[i] != null)
                {
                    anim[i].SetFloat("direction", -1f);
                    anim[i].SetBool("activated", true);
                }
            }
            animationPlaying = true;
            counter = 0;
            StartCoroutine(WaitForAnimation());
        }
    }

    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(2f);
        animationPlaying = false;
    }
}