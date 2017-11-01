﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float zSpeed = .5f;
    public float xSpeed = 10;
    public float jump = 1000;
    float zSpeedTemp;
    bool blink = false;
    float blinkTimer = 0f;
    GameObject[] obstacles;
    Rigidbody rb;
    bool isGrounded = true;

	// Use this for initialization
	void Start () {
        obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        zSpeedTemp = zSpeed;
        rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.A) && isGrounded) {
            transform.position = new Vector3(transform.position.x - xSpeed * Time.deltaTime, transform.position.y, transform.position.z + zSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) && !isGrounded) {
            transform.position = new Vector3(transform.position.x - xSpeed/4 * Time.deltaTime, transform.position.y, transform.position.z + zSpeed * Time.deltaTime);
        }
        else {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && isGrounded) {
            transform.position = new Vector3(transform.position.x + xSpeed * Time.deltaTime, transform.position.y, transform.position.z + zSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) && !isGrounded) {
            transform.position = new Vector3(transform.position.x + xSpeed/4 * Time.deltaTime, transform.position.y, transform.position.z + zSpeed * Time.deltaTime);
        }
        else {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(0, 400, 0);
            isGrounded = false;
        }
        
        if (blink) {
            blinkTimer += Time.deltaTime;
            zSpeed = zSpeedTemp * blinkTimer / 2;
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
        if (collision.transform.tag == "ground") {
            isGrounded = true;
        }
    }

}
