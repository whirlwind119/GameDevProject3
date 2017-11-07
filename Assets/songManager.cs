using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
