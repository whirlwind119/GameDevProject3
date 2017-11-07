using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changingParticles : MonoBehaviour {

	List<GameObject> systems = new List<GameObject>();
	List<GameObject> woofs = new List<GameObject>();
	public GameObject player;

	int prevCol;
	int currentCol;
	int count; 

	AudioSource audio;
	// Use this for initialization
	void Start () {
		
		prevCol = 0;
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		currentCol = player.GetComponent<Movement> ().collisions;
		//Debug.Log ("Current:"+currentDist);
		//Debug.Log ("Previous:"+prevDist);


		if (currentCol > prevCol) {
			
			GameObject ps = (GameObject)Instantiate(Resources.Load("Particle System"));
			ps.transform.position = new Vector3 (this.transform.position.x , this.transform.position.y, this.transform.position.z+2f);
			systems.Add (ps);
			count += 1; 
			//Debug.Log ("ASS: " + changed);
			if (count == 3) {
				//Debug.Log (count);
				GameObject woof = (GameObject)Instantiate (Resources.Load ("woof"));
				woof.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
				woof.transform.localScale = new Vector3 (woof.transform.localScale.x * .5f, woof.transform.localScale.y * .5f, woof.transform.localScale.z * .5f);
				audio = woof.AddComponent<AudioSource> ();
				audio.clip = Resources.Load ("bark") as AudioClip; 
				audio.Play ();
				audio.volume = Random.value;
				audio.panStereo = Random.Range(-1f, 1f);

				woofs.Add (woof);
				count = 0;


			}
			prevCol = currentCol;
			//Debug.Log (woofs.Count);


		}

		for (int i = 0; i < systems.Count; i++) {
			systems[i].transform.position = new Vector3(player.transform.position.x+Random.Range(-5f,5f), player.transform.position.y, player.transform.position.z-1.6f);
		}
		for (int i = 0; i < woofs.Count; i++) {
			woofs [i].transform.position = new Vector3 (player.transform.position.x +Random.Range(-5f,5f), player.transform.position.y +Random.Range(-3f,3f), player.transform.position.z-1.6f);
		}

	}
		
}
