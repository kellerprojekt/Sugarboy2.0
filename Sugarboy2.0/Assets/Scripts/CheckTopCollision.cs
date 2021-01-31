using UnityEngine;
public class CheckTopCollision : MonoBehaviour
{
    [SerializeField] private int groundLayer;
    [SerializeField] private int noCollisionLayer;
    public bool isChild = false;
    private string previousTag;

    [SerializeField] private GameObject obj;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("BottomCollider"))
        {
            obj = collision.gameObject.transform.parent.gameObject;
            obj.GetComponent<PlayerMovement>()._isGrounded = true;
            previousTag = gameObject.transform.parent.gameObject.transform.parent.gameObject.tag;
            gameObject.transform.parent.gameObject.layer = groundLayer;
            gameObject.transform.parent.gameObject.tag = "Ground";
            gameObject.transform.parent.gameObject.transform.parent.gameObject.tag = "Ground";
            obj.transform.SetParent(transform.parent);
            isChild = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        collider.gameObject.transform.parent.GetComponent<PlayerMovement>()._isGrounded = false;
        gameObject.transform.parent.gameObject.transform.parent.gameObject.tag = previousTag;
        gameObject.transform.parent.gameObject.layer = noCollisionLayer;
        gameObject.transform.parent.gameObject.tag = "Untagged";
        obj.transform.SetParent(null);
        isChild = false;
    }
}