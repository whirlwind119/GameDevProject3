using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class songManager : MonoBehaviour {

    public static string currentScene = "";
    public static string previousScene = "";
	bool setSong;
	bool setSong2;

	// Use this for initialization
	void Start () {
        //Debug.Log("TESTING DEBUG LOG");
		setSong = true;
		setSong2 = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(SceneManager.GetActiveScene().name != currentScene)
        {
            previousScene = currentScene;
            currentScene = SceneManager.GetActiveScene().name;
            //Debug.Log("Current Scene: " + currentScene);
            //Debug.Log("Previous Scene: " + previousScene);
        }

		if (setSong && currentScene == "win") {
			AudioSource a = this.gameObject.GetComponent<AudioSource> ();
			a.clip = Resources.Load ("winTheme") as AudioClip;
			a.loop = true;
			a.volume = .5f;
			a.PlayDelayed (0f);
			setSong = false;
			setSong2 = true;
		}
		if (setSong2 && currentScene == "Start Menu") {
			AudioSource a = this.gameObject.GetComponent<AudioSource> (); 
			a.clip = Resources.Load ("skate") as AudioClip;
			a.loop = true; 
			a.volume = .5f; 
			a.PlayDelayed (0f); 
			setSong2 = false; 
			setSong = true;
		}

	}

	void Awake(){
		DontDestroyOnLoad (this.gameObject);
		AudioSource a = this.gameObject.AddComponent<AudioSource> (); 
		a.clip = Resources.Load ("skate") as AudioClip; 
		a.loop = true; 
		a.volume = .5f; 
		a.PlayDelayed (0f);

	}
}
