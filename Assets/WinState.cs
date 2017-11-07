using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour {
	public string nextScene;
    void OnCollisionEnter(Collision coll)
    {
        //Debug.Log("IN HERE", gameObject);
        if (coll.gameObject.tag == "Player")
        {
            //Debug.Log("SCENE CHANGE", gameObject);
			SceneManager.LoadScene(nextScene);
        }
    }
}
