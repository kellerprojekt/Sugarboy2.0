using System;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class MainMenuManager : MonoBehaviour
{
    private readonly string loadUri = "https://sugarboy-server.herokuapp.com/load/";

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/save.json"))
        {
            string jsonString = File.ReadAllText(Application.persistentDataPath + "/save.json");
            JSONObject saveJson = (JSONObject)JSON.Parse(jsonString);

            string uniqueId = saveJson["uniqueId"];

            StartCoroutine(FetchData(uniqueId));
        }
        //if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        //{
        //    BinaryFormatter bf = new BinaryFormatter();
        //    FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
        //    Save save = (Save)bf.Deserialize(file);
        //    file.Close();

        //    SceneManager.LoadScene(save.level);

        //    Debug.Log("Game Loaded");
        //}
        //else
        //{
        //    Debug.Log("No game saved!");
        //}
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
            SceneManager.LoadScene(level);
        }
    }

    public void loadStartScene()
    {
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}