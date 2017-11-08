using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public string target = "";
    public float speed = 20;
    public float clamp = 100;
    Vector3 scale;

    GameObject tracked;


    // Use this for initialization
    void Start() {
        tracked = GameObject.Find(target);
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log(tracked.transform.position.z - transform.position.z, this);
        if (tracked.transform.position.z - transform.position.z > clamp + 2) {
            transform.position = new Vector3(transform.position.x, transform.position.y, tracked.transform.position.z - clamp);
        }
        else {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
        }


    }
}