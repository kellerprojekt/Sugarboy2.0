using UnityEngine;

public class CloneManager : MonoBehaviour
{
    private PlayerControls controls;

    private void Awake()
    {
        //controls = new PlayerControls();
        //controls.Gameplay.DeleteClones.performed += _ => DeleteClones();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    //Deletes all active clones and clears the list
    private void DeleteClones()
    {
        //GameManager.Instance.ClearList();
        GameManager.Instance.ResetAllowedClones();
        GameManager.Instance.activePlayer.tag = "Player";
    }
}