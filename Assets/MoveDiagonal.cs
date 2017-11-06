using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDiagonal : MonoBehaviour {
    public float zSpeed = 10;
    public float ySpeed = -5;
    public float xSpeed = 10;

    public float upBound = 30;
    public float downBound = 50;
    public float leftBound = 10;
    public float rightBound = 20;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.z <= upBound && zSpeed < 0)
        {
            zSpeed *= -1;
            ySpeed *= -1;
        }
        else if (gameObject.transform.position.z >= downBound && zSpeed > 0)
        {
            zSpeed *= -1;
            ySpeed *= -1;
        }
        if(gameObject.transform.position.x <= leftBound && xSpeed < 0)
        {
            xSpeed *= -1;
        }
        else if (gameObject.transform.position.x >= rightBound && xSpeed > 0)
        {
            xSpeed *= -1;
        }
        transform.position = new Vector3(transform.position.x +xSpeed * Time.deltaTime, transform.position.y + ySpeed * Time.deltaTime, transform.position.z + zSpeed * Time.deltaTime);
    }
}
