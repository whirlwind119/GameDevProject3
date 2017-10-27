using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float zSpeed = 10;
    public float xSpeed = 10;
    float zSpeedTemp;
    bool blink = false;
    float blinkTimer = 0f;
    GameObject[] obstacles;

	// Use this for initialization
	void Start () {
        obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        zSpeedTemp = zSpeed;

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.A)) {
            transform.position = new Vector3(transform.position.x - xSpeed * Time.deltaTime, transform.position.y, transform.position.z + zSpeed * Time.deltaTime);
        }
        else {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.position = new Vector3(transform.position.x + xSpeed * Time.deltaTime, transform.position.y, transform.position.z + zSpeed * Time.deltaTime);
        }
        else {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zSpeed * Time.deltaTime);
        }
        
        if (blink) {
            blinkTimer += Time.deltaTime;
            zSpeed = zSpeedTemp * blinkTimer / 2;
            Debug.Log(zSpeed);
        }
        if (blinkTimer < 2f && blink) {
            foreach (GameObject obstacle in obstacles) {
                Physics.IgnoreCollision(obstacle.GetComponent<Collider>(), GetComponent<Collider>());
            }
        }
        if(blinkTimer >= 2f) {
            zSpeed = zSpeedTemp;
            blink = false;
            foreach (GameObject obstacle in obstacles) {
                Physics.IgnoreCollision(obstacle.GetComponent<Collider>(), GetComponent<Collider>(), false);
            }
        }
        

	}
    
    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.tag == "obstacle") {
            blink = true;
            blinkTimer = 0f;
            zSpeed = 0;
        }
    }
    
}
