using UnityEngine;

public class CloneManager : MonoBehaviour {
    [SerializeField] private GameObject clone;

    private void Update () {
        if (Input.GetKeyDown (KeyCode.H)) {
            DeleteClones ();
        }
    }

    //Deletes all active clones and clears the list
    private void DeleteClones () {
        GameManager.Instance.ClearList ();
        GameManager.Instance.ResetAllowedClones ();
        GameManager.Instance.activePlayer.tag = "Player";
    }

}