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


		if (power && Time.time -powerTimer <= 7f) {
			//Debug.Log ("POWER");
			player.GetComponent<Movement>().airModifier = air;
			//Debug.Log (player.GetComponent<Movement> ().airModifier);
		}
		if (power && Time.time - powerTimer > 7f) {
			power = false; 
			player.GetComponent<Movement> ().airModifier = constAir;
			powerTimer = 0f;
			GameObject haloHolder = player.gameObject.transform.FindChild ("haloHolder").gameObject;
			Behaviour halo = (Behaviour)haloHolder.GetComponent ("Halo");
			halo.enabled = false;
		}
	}

	void OnTriggerEnter(Collider other){
        //Debug.Log("asdf");
		power = true;
		player = other;
		powerTimer = Time.time;
		constAir = player.GetComponent<Movement>().airModifier;
		GameObject haloHolder = player.gameObject.transform.FindChild ("haloHolder").gameObject;
		Behaviour halo = (Behaviour)haloHolder.GetComponent ("Halo");
		halo.enabled = true;
	}
}
