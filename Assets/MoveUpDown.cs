using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour {
    public float zSpeed = 10;
    public float ySpeed = -5;

    public float upBound = 30;
    public float downBound = 50;

    private float startZ;

    // Use this for initialization
    void Start () {
        startZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z <= startZ-upBound && zSpeed < 0)
        {
            zSpeed *= -1;
            ySpeed *= -1;
        }
        else if (gameObject.transform.position.z >= startZ +downBound && zSpeed > 0)
        {
            zSpeed *= -1;
            ySpeed *= -1;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + ySpeed * Time.deltaTime, transform.position.z + zSpeed * Time.deltaTime);
    }
}
