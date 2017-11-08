using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    public float zSpeed = .5f;
    public float xSpeed = 10;
    public float jump = 1000;
    public int loseDist = 5;
    public int collisions;
    public GameObject loseTrigger;

    bool isBlinking = false;
    float zSpeedTemp;
    bool blink = false;
    float blinkTimer = 0f;
    GameObject[] obstacles;
    Rigidbody rb;
    bool isGrounded = true;
    public float airModifier = .75f;
    float constZSpeed;

    // Use this for initialization
    void Start() {
        zSpeedTemp = zSpeed;
        rb = GetComponent<Rigidbody>();
        constZSpeed = zSpeed;
        collisions = 0;
        obstacles = GameObject.FindGameObjectsWithTag("obstacle");

    }

    // Update is called once per frame
    void Update() {
		Debug.Log ("existing");
        if (transform.position.z - loseTrigger.transform.position.z < loseDist) {
            //Debug.Log ("here");
            SceneManager.LoadScene("lose", LoadSceneMode.Single);
        }
        if (Input.GetKey(KeyCode.A) && isGrounded) {
            transform.position = new Vector3(transform.position.x - xSpeed * Time.deltaTime, transform.position.y, transform.position.z + zSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) && !isGrounded) {
            transform.position = new Vector3(transform.position.x - xSpeed / 4 * Time.deltaTime, transform.position.y, transform.position.z + zSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) && isGrounded) {
            transform.position = new Vector3(transform.position.x + xSpeed * Time.deltaTime, transform.position.y, transform.position.z + zSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) && !isGrounded) {
            transform.position = new Vector3(transform.position.x + xSpeed / 4 * Time.deltaTime, transform.position.y, transform.position.z + zSpeed * Time.deltaTime);
        }
        else {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(0, 400, 0);
            isGrounded = false;
            zSpeed = zSpeed * airModifier;
        }

        if (blinkTimer < 3f) {
            blinkTimer += Time.deltaTime;
            zSpeed = zSpeedTemp * blinkTimer / 3;
        }
        else {
            zSpeed = zSpeedTemp;
        }
        if (blinkTimer < 2f && blink) {
            if (!isBlinking) {
                Debug.Log("Start Blinking");
                isBlinking = true;
                StartCoroutine(Blink(2.0f));
            }
            foreach (GameObject obstacle in obstacles) {
                Physics.IgnoreCollision(obstacle.GetComponent<Collider>(), GetComponent<Collider>());
            }
        }
        if (blink && blinkTimer >= 2f) {
            blink = false;
            foreach (GameObject obstacle in obstacles) {
                Physics.IgnoreCollision(obstacle.GetComponent<Collider>(), GetComponent<Collider>(), false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "obstacle") {
            obstacles = GameObject.FindGameObjectsWithTag("obstacle");
            blink = true;
            blinkTimer = 0f;
            zSpeed = 1;
            collisions += 1;
        }
        if (collision.transform.tag == "ground") {
            isGrounded = true;
            zSpeed = constZSpeed;
        }
    }

    private IEnumerator Blink(float waitTime) {
        Component[] meshRenderers;
        meshRenderers = GetComponentsInChildren<MeshRenderer>();

        var endTime = Time.time + waitTime;
        while (Time.time < endTime) {
            Debug.Log("BLINKING");
            foreach (MeshRenderer mesh in meshRenderers) {
                mesh.enabled = false;
            }
            yield return new WaitForSeconds(0.2f);
            foreach (MeshRenderer mesh in meshRenderers) {
                mesh.enabled = true;
            }
            yield return new WaitForSeconds(0.2f);
        }

        isBlinking = false;

    }
}