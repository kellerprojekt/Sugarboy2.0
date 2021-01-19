using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{

    private PlayerControls controls;
    [SerializeField]
    private GameObject menu;
    private bool isPaused = false;
    public int currentScene;

    public void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.PauseGame.performed += _ => Pause();
        Unpause();
    }

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        currentScene = scene.buildIndex;
        Debug.Log("Active Scene is '" + scene.buildIndex + "'.");
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    public void Pause()
    {
        menu.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Unpause()
    {
        menu.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
        isPaused = false;
    }

    public bool IsGamePaused()
    {
        return isPaused;
    }

    public void SaveGame()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Game Saved");
        Debug.Log(currentScene);
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        save.savedScene = currentScene;

        return save;
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            SceneManager.LoadScene(save.savedScene);

            Debug.Log("Game Loaded");

            Unpause();
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }

    public void backToStart()
    {
        SceneManager.LoadScene(0);
    }

}
