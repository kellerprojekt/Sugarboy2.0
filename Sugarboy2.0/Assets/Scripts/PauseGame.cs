﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using SimpleJSON;
using Proyecto26;
using UnityEngine.Networking;

public class PauseGame : MonoBehaviour
{
    private PlayerControls controls;

    [SerializeField]
    private GameObject menu;

    private bool isPaused = false;
    public int currentScene;

    private readonly string postUri = "http://localhost:5000/save";
    private readonly string loadUri = "http://localhost:5000/load/";

    private JSONObject saveObj;
    private RequestHelper rh;

    public void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.PauseGame.performed += _ => Pause();
        Unpause();
    }

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
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

        saveObj = new JSONObject();
        saveObj.Add("uniqueId", save.uniqueId);
        saveObj.Add("level", save.level);

        File.WriteAllText(Application.persistentDataPath + "/save.json", saveObj.ToString());

        rh = new RequestHelper
        {
            Uri = postUri,
            Body = new Save
            {
                level = save.level,
                uniqueId = SystemInfo.deviceUniqueIdentifier
            }
        };

        RestClient.Post(rh).Then(res =>
        {
            //Cant figure out why my message from the server is not being sent over
            Debug.Log(JsonUtility.ToJson(res, true));
        }).Catch(err => { Debug.LogError(err.Message); });

        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        //bf.Serialize(file, save);
        //file.Close();

        //Debug.Log("Game Saved");
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        save.level = currentScene;
        save.uniqueId = SystemInfo.deviceUniqueIdentifier;

        return save;
    }

    private IEnumerator FetchData(string id)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(loadUri + id))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
                yield break;
            }

            JSONNode data = JSON.Parse(webRequest.downloadHandler.text);

            int level = data["level"];
            Debug.Log(level);
        }
    }

    public void LoadGame()
    {
        string jsonString = File.ReadAllText(Application.persistentDataPath + "/save.json");
        JSONObject saveJson = (JSONObject)JSON.Parse(jsonString);

        string uniqueId = saveJson["uniqueId"];

        StartCoroutine(FetchData(uniqueId));

        //if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        //{
        //    BinaryFormatter bf = new BinaryFormatter();
        //    FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
        //    Save save = (Save)bf.Deserialize(file);
        //    file.Close();

        //    SceneManager.LoadScene(save.savedScene);

        //    Debug.Log("Game Loaded");

        //    Unpause();
        //}
        //else
        //{
        //    Debug.Log("No game saved!");
        //}
    }
}