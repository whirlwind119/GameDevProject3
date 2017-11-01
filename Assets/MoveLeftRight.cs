using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour {

    public float xSpeed = 10;

    public float lBound = 4;
    public float rBound = 6;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.x <= lBound && xSpeed < 0)
        {
            xSpeed *= -1;
        }
        else if (gameObject.transform.position.x >= rBound && xSpeed > 0)
        {
            xSpeed *= -1;
        }
        transform.position = new Vector3(transform.position.x + xSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
