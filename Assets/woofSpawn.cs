using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woofSpawn : MonoBehaviour {
	bool fadeIn;
	float targetTime;
	float spawnTime;
	// Use this for initialization
	void Start () {
		fadeIn = true;
		targetTime = Random.Range(0f, 3f);
		spawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		

		if (Time.time - spawnTime >= targetTime) {
			if (fadeIn) {
				gameObject.GetComponent<Renderer> ().material.color = new Color (gameObject.GetComponent<Renderer> ().material.color.r, gameObject.GetComponent<Renderer> ().material.color.g, gameObject.GetComponent<Renderer> ().material.color.b, gameObject.GetComponent<Renderer> ().material.color.a + .01f);
				gameObject.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y+.2f , this.transform.position.z);
				if (gameObject.GetComponent<Renderer>().material.color.a >= 1f) {
					fadeIn = false;
				}
			} 
			else {
				gameObject.GetComponent<Renderer>().material.color = new Color (gameObject.GetComponent<Renderer> ().material.color.r, gameObject.GetComponent<Renderer> ().material.color.g, gameObject.GetComponent<Renderer> ().material.color.b, gameObject.GetComponent<Renderer> ().material.color.a - .01f); 
				gameObject.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y-.2f, this.transform.position.z);
				if (gameObject.GetComponent<Renderer>().material.color.a <= 0f) {
					fadeIn = true;
				}
			}
		}

	}
}
