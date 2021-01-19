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
    private RequestHelper request;

    // Start is called before the first frame update
    private void Start()
    {
        //StartCoroutine(GetRequest("http://localhost:5000/load/44efad66cb9556f3485b7af286e82a1f13f9c03a"));
        ////Post();
    }

    private void Post()
    {
        request = new RequestHelper
        {
            Uri = "http://localhost:5000/hello",
            Body = new Test
            {
                name = "AA",
                value = 2
            }
        };

        RestClient.Post(request).Then(res =>
        {
            Debug.Log(JsonUtility.ToJson(res, true));
        });
    }

    private IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.LogError(webRequest.error);
                yield break;
            }

            JSONNode data = JSON.Parse(webRequest.downloadHandler.text);

            string name = data["level"];
            Debug.Log(name);
        }
    }
}

[Serializable]
public class Test
{
    public string name;
    public int value;
}