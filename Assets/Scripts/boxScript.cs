using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class boxScript : MonoBehaviour {
    public SpriteRenderer  spriteRender1;
    public Sprite  sprite1;
    public string displayScreen;
    public float x = 0;
    public float y = 0;
    public int z;

    public AudioClip source1;
    public AudioClip source2;
    public AudioClip source3;
    public AudioClip source4;
    public AudioClip source5;
    public AudioClip source6;
    public AudioClip source7;
    public AudioClip source8;
    public AudioClip source9;
    public AudioClip source10;


    public AudioSource AudioS;
    public AudioSource AudioS1;
    public AudioSource AudioS2;
    public AudioSource AudioS3;
    public AudioSource AudioS4;
    public AudioSource AudioS5;
    public AudioSource AudioS6;
    public AudioSource AudioS7;
    public AudioSource AudioS8;
    public AudioSource AudioS9;

    // Use this for initialization
    void Start () {

        AudioS.clip = source1;
        AudioS1.clip = source2;
        AudioS2.clip = source3;
        AudioS3.clip = source4;
        AudioS4.clip = source5;
        AudioS5.clip = source6;
        AudioS6.clip = source7;
        AudioS7.clip = source8;
        AudioS8.clip = source9;
        AudioS9.clip = source10;
    }
	
	// Update is called once per frame
	void Update () {
		
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
            displayScreen = split[5];
            Debug.Log("GET Received: " + split[5]);

        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        y = Random.Range(1, 10);
        z = (int)y;

        switch (z)
        {
            case 1:
                AudioS.PlayOneShot(source1, 1);
                break;
            case 2:
                AudioS.PlayOneShot(source2, 1);
                break;
            case 3:
                AudioS.PlayOneShot(source3, 1);
                break;
            case 4:
                AudioS.PlayOneShot(source4, 1);
                break;
            case 5:
                AudioS.PlayOneShot(source5, 1);
                break;
            case 6:
                AudioS.PlayOneShot(source6, 1);
                break;
            case 7:
                AudioS.PlayOneShot(source7, 1);
                break;
            case 8:
                AudioS.PlayOneShot(source8, 1);
                break;
            case 9:
                AudioS.PlayOneShot(source9, 1);
                break;
            case 10:
                AudioS.PlayOneShot(source10, 1);
                break;
            default:
                Debug.Log("Default case");
                break;
        }




        if (coll.gameObject.tag == "Player")
        {

            StartCoroutine(getRequest("https://en.wikipedia.org/wiki/Special:RandomInCategory/Innovation"));
            spriteRender1.sprite = sprite1;
            GetComponent<BoxCollider2D>().enabled = false;
        }

         x = Time.time + 3;

    }

    void OnGUI()
    {
        // Make a group on the center of the screen
        //GUI.BeginGroup(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100));
        // All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.

        // We'll make a box so you can see where the group is on-screen.

        //GUI.Box(new Rect(0, 0, 100, 100), "Brainstorm material:");
        //GUI.Label(new Rect(10, 40, 80, 30), displayScreen);
        if (Time.time < x)
        {
            GUILayout.BeginArea(new Rect(Screen.width / 3, 100, 300, 100));
            GUILayout.Label(displayScreen, GUILayout.MinWidth(50));
            // End the group we started above. This is very important to remember!
            GUILayout.EndArea();
            //GUI.EndGroup();
        }
    }
}
