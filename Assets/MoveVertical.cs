using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertical : MonoBehaviour {
    public float ySpeed = -5;

    public float upBound = 30;
    public float downBound = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.y <= downBound && ySpeed < 0)
        {
            ySpeed *= -1;
        }
        else if (gameObject.transform.position.y >= upBound && ySpeed > 0)
        {
            ySpeed *= -1;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + ySpeed * Time.deltaTime, transform.position.z);
    }
}
