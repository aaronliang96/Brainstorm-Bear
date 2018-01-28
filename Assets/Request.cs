using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Request : MonoBehaviour {

    //public Text displayText;

    //// Use this for initialization
    //void Start()
    //{
    //    print("A");
    //    string url = "http://www.google.com";
    //    WWWForm formDate = new WWWForm();
    //    print("B");
    //    formDate.AddField("username", "aaron");
    //    print("C");
    //    WWW www = new WWW(url, formDate);
    //    StartCoroutine(WaitForRequest(www));
    //    print("D");
    //}

    //IEnumerator WaitForRequest(WWW www)
    //{
    //    yield return www;
    //    displayText.text = www.data;

    //    // check for errors
    //    if (www.error == null)
    //    {
    //        print("NO ERROR");
    //        Debug.Log("WWW Ok!: " + www.text);
    //    }
    //    else
    //    {
    //        print("YES ERROR");
    //        Debug.Log("WWW Error: " + www.error);
    //    }
    //}

    //void OnGUI()
    //{
    //    GUILayout.Button(split[5], GUILayout.Width(600));
    //}
    public string displayScreen;
    
    void Start()
    {
        StartCoroutine(getRequest("https://en.wikipedia.org/wiki/Special:RandomInCategory/Concepts_in_physics"));
    }

    IEnumerator getRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("GET Error While Sending: " + uwr.error);
        }
        else
        {
            string[] split = uwr.downloadHandler.text.Split('>');
            split[5] = split[5].Substring(0, split[5].Length - 19);
            displayScreen= split[5]; 
            Debug.Log("GET Received: " + split[5]);
            
        }
    }
    public GUIStyle style;
    void OnGUI()
    {
        // Make a group on the center of the screen
        //GUI.BeginGroup(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100));
        // All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.

        // We'll make a box so you can see where the group is on-screen.

        //GUI.Box(new Rect(0, 0, 100, 100), "Brainstorm material:");
        //GUI.Label(new Rect(10, 40, 80, 30), displayScreen);
        GUILayout.BeginArea(new Rect(Screen.width/3, 100, 300, 100));
        GUI.skin.label = style;
        GUILayout.Label(displayScreen, GUILayout.MinWidth(50));
       
        // End the group we started above. This is very important to remember!
        GUILayout.EndArea();
        //GUI.EndGroup();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
