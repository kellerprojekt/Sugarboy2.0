using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloneDisplay : MonoBehaviour
{
    [SerializeField] private Text cloneDisplay;

    private void Update()
    {
        cloneDisplay.text = $" {GameManager.Instance.AllowedClones} / {GameManager.Instance.AllowedClonesReset}";
    }
}