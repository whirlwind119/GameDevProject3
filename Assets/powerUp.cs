using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour {
	GameObject [] obstacles;
	bool power = false;
	float powerTimer = 0;
	Collider player;
	// Use this for initialization
	void Start () {
		obstacles = GameObject.FindGameObjectsWithTag("obstacle");
	}
	
	// Update is called once per frame
	void Update () {


		if (power && Time.time -powerTimer <= 15f) {
			//Debug.Log ("POWER");
			foreach (GameObject obstacle in obstacles) {
				Physics.IgnoreCollision(obstacle.GetComponent<Collider>(), player.GetComponent<Collider>());
			}
		}
		if (Time.time - powerTimer > 15f) {
			power = false; 
			foreach (GameObject obstacle in obstacles) {
				Physics.IgnoreCollision(obstacle.GetComponent<Collider>(), player.GetComponent<Collider>(),false);
			}
			powerTimer = 0f;

		}
	}

	void OnTriggerEnter(Collider other){
		power = true;
		player = other;
		powerTimer = Time.time;
	}
}
