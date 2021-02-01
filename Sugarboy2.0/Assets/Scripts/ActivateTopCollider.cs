using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTopCollider : MonoBehaviour
{
    [SerializeField] private string colliderTag;
    private bool colliderActivated = false;

    private void Update()
    {
        ActivateCollider();
    }

    private void ActivateCollider()
    {
        if (gameObject.tag.Contains("Player_") && !colliderActivated)
        {
            GameObject obj = gameObject.transform.Find(colliderTag).gameObject;
            obj.SetActive(true);
            colliderActivated = !colliderActivated;
        }
    }
}