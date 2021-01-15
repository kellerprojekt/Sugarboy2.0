using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTopCollision : MonoBehaviour
{
    [SerializeField] private int groundLayer;
    [SerializeField] private int noCollisionLayer;

    [SerializeField] private GameObject obj;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("BottomCollider"))
        {
            obj = collision.gameObject.transform.parent.gameObject;
            gameObject.transform.parent.gameObject.layer = groundLayer;
            obj.transform.SetParent(transform.parent);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        gameObject.transform.parent.gameObject.layer = noCollisionLayer;
        obj.transform.SetParent(null);
    }
}