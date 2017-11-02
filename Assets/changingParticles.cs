using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changingParticles : MonoBehaviour {

	List<GameObject> systems = new List<GameObject>();
	List<GameObject> woofs = new List<GameObject>();
	public GameObject player;
	public GameObject dogs;
	float prevDist;
	float currentDist;
	int changed = 0;
	AudioSource audio;
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		prevDist = currentDist;
		currentDist = Vector3.Distance (player.transform.position, dogs.transform.position);
		//Debug.Log ("Current:"+currentDist);
		//Debug.Log ("Previous:"+prevDist);


		if (currentDist < prevDist) {
			
			GameObject ps = (GameObject)Instantiate(Resources.Load("Particle System"));
			ps.transform.position = new Vector3 (this.transform.position.x , this.transform.position.y, this.transform.position.z+2f);
			systems.Add (ps);
			changed += 1;
			//Debug.Log ("ASS: " + changed);
			if (changed == 20) {
				
				GameObject woof = (GameObject)Instantiate (Resources.Load ("woof"));
				woof.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
				woofs.Add (woof);

				audio = woof.AddComponent<AudioSource> ();
				audio.clip = Resources.Load ("bark") as AudioClip; 
				audio.Play ();
				audio.volume = Random.value;
				audio.panStereo = Random.Range(-1f, 1f);
				changed = 0;
			}



		}

		for (int i = 0; i < systems.Count; i++) {
			systems[i].transform.position = new Vector3(player.transform.position.x+Random.Range(-5f,5f), player.transform.position.y, player.transform.position.z-1.6f);
		}
		for (int i = 0; i < woofs.Count; i++) {
			woofs [i].transform.position = new Vector3 (player.transform.position.x +Random.Range(-5f,5f), player.transform.position.y +Random.Range(-3f,3f), player.transform.position.z-1.6f);
		}

	}
		
}
