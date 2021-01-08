using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {
    private PlayerControls controls;

    private void Awake () {
        controls = new PlayerControls ();
        controls.Gameplay.RestartGame.performed += _ => Restart ();
    }
    private void OnEnable () {
        controls.Gameplay.Enable ();
    }

    private void OnDisable () {
        controls.Gameplay.Disable ();
    }
    private void Restart () {

        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
    }
}