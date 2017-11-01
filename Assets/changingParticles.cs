using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changingParticles : MonoBehaviour {
	int count = 0; 
	List<GameObject> systems = new List<GameObject>();
	List<GameObject> woofs = new List<GameObject>();
	public GameObject player;
	public 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		int prevCount = count;
		if (Input.GetKeyDown (KeyCode.Space)) {
			count += 1; 
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			count -= 1;		
		}
		if (count > prevCount) {

			GameObject ps = (GameObject)Instantiate(Resources.Load("Particle System"));
			ps.transform.position = new Vector3 (this.transform.position.x , this.transform.position.y, this.transform.position.z+2f);
			systems.Add (ps);
			GameObject woof = (GameObject)Instantiate (Resources.Load ("woof"));
			woof.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
			woofs.Add (woof);
		}
		if (count < prevCount && systems.Count >0) {
			int i = systems.Count; 
			GameObject ps = systems [i - 1]; 
			systems.Remove (ps);
			Destroy (ps);
			i = woofs.Count; 
			GameObject woof = woofs [i - 1];
			woofs.Remove (woof);
			Destroy (woof);
	
		}

		for (int i = 0; i < systems.Count; i++) {
			systems[i].transform.position = new Vector3(player.transform.position.x+Random.Range(-5f,5f), player.transform.position.y, player.transform.position.z-1.6f);
		}
		for (int i = 0; i < woofs.Count; i++) {
			woofs [i].transform.position = new Vector3 (player.transform.position.x +Random.Range(-5f,5f), player.transform.position.y +Random.Range(-3f,3f), player.transform.position.z-1.6f);
		}
	}
		
}
