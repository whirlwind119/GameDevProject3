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
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {

		currentDist = Vector3.Distance (player.transform.position, dogs.transform.position);


		if (currentDist < prevDist) {
			//Debug.Log ("here");
			GameObject ps = (GameObject)Instantiate(Resources.Load("Particle System"));
			ps.transform.position = new Vector3 (this.transform.position.x , this.transform.position.y, this.transform.position.z+2f);
			systems.Add (ps);
			changed += 1;
			if (changed == 5) {
				GameObject woof = (GameObject)Instantiate (Resources.Load ("woof"));
				woof.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
				woofs.Add (woof);
				changed = 0;
			}



		}
		/*if (currentDist > prevDist && systems.Count > 0) {
			Debug.Log ("here2");
			int i = systems.Count; 
			GameObject ps = systems [i - 1]; 
			systems.Remove (ps);
			Destroy (ps);
			i = woofs.Count; 
			GameObject woof = woofs [i - 1];
			woofs.Remove (woof);
			Destroy (woof);
	
		}*/

		for (int i = 0; i < systems.Count; i++) {
			systems[i].transform.position = new Vector3(player.transform.position.x+Random.Range(-5f,5f), player.transform.position.y, player.transform.position.z-1.6f);
		}
		for (int i = 0; i < woofs.Count; i++) {
			woofs [i].transform.position = new Vector3 (player.transform.position.x +Random.Range(-5f,5f), player.transform.position.y +Random.Range(-3f,3f), player.transform.position.z-1.6f);
		}
		prevDist = currentDist;
	}
		
}
