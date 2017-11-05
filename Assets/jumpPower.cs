using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPower : MonoBehaviour {
	public float air; 
	bool power = false;
	float powerTimer = 0;
	Collider player;
	float constAir;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {


		if (power && Time.time -powerTimer <= 5f) {
			//Debug.Log ("POWER");
			player.GetComponent<Movement>().airModifier = air;
			//Debug.Log (player.GetComponent<Movement> ().airModifier);
		}
		if (power && Time.time - powerTimer > 5f) {
			power = false; 
			player.GetComponent<Movement> ().airModifier = constAir;
			powerTimer = 0f;

		}
	}

	void OnTriggerEnter(Collider other){
		power = true;
		player = other;
		powerTimer = Time.time;
		constAir = player.GetComponent<Movement>().airModifier;
	}
}
