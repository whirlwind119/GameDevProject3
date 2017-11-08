using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changingParticles : MonoBehaviour {

	List<GameObject> systems = new List<GameObject>();
	List<GameObject> woofs = new List<GameObject>();
	List<AudioClip> barks = new List<AudioClip>(); 
	public GameObject player;
    public GameObject follower;
    public float threshold = 3;
    public float limit = 41;


	int count; 


	AudioSource audio;
	// Use this for initialization
	void Start () {

		barks.Add (Resources.Load ("bark1")as AudioClip); 
		barks.Add (Resources.Load ("bark2")as AudioClip);
		barks.Add (Resources.Load ("bark3")as AudioClip);
		count = 0;

	}
	
	// Update is called once per frame
	void Update () {

        if ((count + 1) * threshold < limit - (player.transform.position.z - follower.transform.position.z)) {

            //Debug.Log(limit - (player.transform.position.z - follower.transform.position.z), this);
            //Debug.Log(count, this);
            //Debug.Log("add");

            GameObject ps = (GameObject)Instantiate(Resources.Load("Particle System"));
            ps.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 2f);
            systems.Add(ps);
            //Debug.Log ("ASS: " + changed);
            if (count % 3 == 2) {
                //Debug.Log (count);
                GameObject woof = (GameObject)Instantiate(Resources.Load("woof"));
                woof.transform.position = new Vector3(this.transform.position.x + Random.Range(-5f, 5f), this.transform.position.y, this.transform.position.z);
                float scale = Random.Range(0f, .3f);
                woof.transform.localScale = new Vector3(scale, scale, scale);

                audio = woof.AddComponent<AudioSource>();
                audio.clip = barks[Random.Range(0, 2)];
                audio.volume = Random.Range(.2f, .6f);
                audio.panStereo = Random.Range(-10f, 10f);
                audio.loop = true;
                audio.PlayDelayed(Random.Range(0f, 6f));

                woofs.Add(woof);

            }
            count++;
        }
        else if (count * threshold > limit - (player.transform.position.z - follower.transform.position.z))
        {

            //Debug.Log(limit - (player.transform.position.z - follower.transform.position.z), this);
            //Debug.Log("remove", this);
            if (systems.Count != 0) {
                GameObject ps = systems[systems.Count - 1];
                systems.Remove(ps);
                Destroy(ps);
            }
            if((count - 1) % 3 == 2)
            {
                if (woofs.Count != 0)
                {
                    Destroy(woofs[woofs.Count - 1]);
                    woofs.RemoveAt(woofs.Count - 1);
                    
                }
            }
            count--;
        }

		for (int i = 0; i < systems.Count; i++) {
            
            //Debug.Log(systems.Count);
			systems[i].transform.position = new Vector3(player.transform.position.x+Random.Range(-5f,5f), player.transform.position.y, player.transform.position.z-1.6f);
		}
		for (int i = 0; i < woofs.Count; i++) {
			woofs [i].transform.position = new Vector3 (woofs[i].transform.position.x , player.transform.position.y+1f, player.transform.position.z-1.6f);
			woofs [i].transform.localScale = new Vector3 (Mathf.PingPong (Time.time*.8f , .3f), Mathf.PingPong (Time.time*.8f , .3f), Mathf.PingPong (Time.time*.8f , .3f));
		}

	}
		
}
