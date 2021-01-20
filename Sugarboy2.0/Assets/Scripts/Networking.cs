using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using Proyecto26;
using System;
using UnityEngine.SceneManagement;

public class Networking : MonoBehaviour
{
    private IEnumerator FetchData(string id, string loadUri)
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
}