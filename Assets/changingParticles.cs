using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changingParticles : MonoBehaviour {
	int count = 0; 
	List<GameObject> systems = new List<GameObject>();
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
			ps.transform.position = new Vector3 (this.transform.position.x + Random.Range(.25f,.75f), this.transform.position.y +Random.Range(.25f,.75f), this.transform.position.z);
			systems.Add (ps);
		}
		if (count < prevCount && systems.Count >0) {
			int i = systems.Count; 
			GameObject ps = systems [i - 1]; 
			systems.Remove (ps);
			Destroy (ps);
	
		}
	}
		
}
