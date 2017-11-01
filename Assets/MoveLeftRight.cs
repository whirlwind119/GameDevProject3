using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour {

    public float xSpeed = 10;
    public float ySpeed = -5;

    public float lBound = 10;
    public float rBound = 30;

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
        transform.position = new Vector3(transform.position.x + xSpeed * Time.deltaTime, transform.position.y + ySpeed * Time.deltaTime, transform.position.z);
    }
}
