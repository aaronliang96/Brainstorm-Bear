using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class POSTrequest : MonoBehaviour {

    void Start()
    {
        StartCoroutine(postRequest("http://www.google.com/search?"));
    }

    IEnumerator postRequest(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("q", "Technology");
        //form.AddField("Game Name", "Mario Kart");

        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("POST Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("POST Received: " + uwr.downloadHandler.text);
        }
    }
}
