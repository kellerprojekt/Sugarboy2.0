using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    private Text messageText;
    public Animator transition;
    public float transitionTime = 1f;
    public List<string> introTexts = new List<string>();

    private void Awake()
    {
        messageText = transform.Find("Transition").Find("Image").Find("messageText").GetComponent<Text>();
        introTexts.Add("Welcome");
        introTexts.Add("Tutorial 1");
        introTexts.Add("Tutorial 2");
        introTexts.Add("Level 1");
        introTexts.Add("Level 2");
    }

    private void Start()
    {
        TextWriter.AddWriter_Static(messageText, introTexts[SceneManager.GetActiveScene().buildIndex], .1f, true);
    }

    private void OnTriggerEnter(Collider other)
    {
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("EndLevel");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

}
