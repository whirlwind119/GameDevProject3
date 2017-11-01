using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public string target = "";
    public bool x = true;
    public bool y = true;
    public bool z = true;
    public float speed = 20;
    public float clamp = 100;
    public float min = 10;
    Vector3 scale;

    GameObject tracked;


	// Use this for initialization
	void Start ()
    {
        scale = new Vector3(0, 0, 0);
        if(x)
        {
            scale.x += 1;
        }
        if(y)
        {
            scale.y += 1;
        }
        if(z)
        {
            scale.z += 1;
        }
        tracked = GameObject.Find(target);
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(tracked.transform);

        Vector3 adv = Vector3.Scale(transform.forward, scale);

        if ((transform.position - tracked.transform.position).magnitude > clamp)
        {
            transform.position += adv * ((transform.position - tracked.transform.position).magnitude - clamp);
        }
        else if((transform.position - tracked.transform.position).magnitude < min)
        {

        }
        else
        {
            transform.position += adv * speed * Time.deltaTime;
        }


	}
}
