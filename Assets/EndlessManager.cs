using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessManager : MonoBehaviour {

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;

    private int random;
    private GameObject current;
    private GameObject next;
    private GameObject player;
    private GameObject background;
    private GameObject floor;
    private float backgroundDistance;
    private float fakeGroundDistance;
    private int counter;
    private int counter2;
    private List<GameObject> path = new List<GameObject>();

    // Use this for initialization
    void Start () {
        counter = 1;
        counter2 = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        background = GameObject.Find("background");
        floor = GameObject.Find("fakeGround");
        random = Random.Range(1, 5);
        current = Instantiate(pickLevel(random), new Vector3(0f, 0f, 0f), Quaternion.identity);
        path.Add(current);
        random = Random.Range(1, 5);
        next = pickLevel(random);
        if (next == current) {
            selectNext(random);
        }
        next = Instantiate(next, new Vector3(0f, 0f, 172.2f * counter), Quaternion.identity);
        path.Add(next);
        backgroundDistance = (player.transform.position - background.transform.position).magnitude;
        fakeGroundDistance = (player.transform.position - floor.transform.position).magnitude;
    }
	
	// Update is called once per frame
	void Update () {
        background.transform.position = (background.transform.position - player.transform.position).normalized * backgroundDistance + player.transform.position;
        floor.transform.position = (floor.transform.position - player.transform.position).normalized * fakeGroundDistance + player.transform.position;
        if (player.transform.position.z > 86.1f + 172.2*counter2) {
            counter++;
            counter2++;
            current = next;
            random = Random.Range(1, 5);
            next = pickLevel(random);
            if (next == current) {
                selectNext(random);
            }
            
            GameObject temp = current;
            next = Instantiate(next, new Vector3(0f, 0f, 172.2f * counter), Quaternion.identity);
            path.Add(next);
            temp = path[0];
            path.Remove(path[0]);
            Destroy(temp);
        }
    }

    private GameObject pickLevel(int randomInt) {
        GameObject to_return = null;
        if (randomInt == 1) {
            to_return = level1;
        }
        if (randomInt == 2) {
            to_return = level2;
        }
        if (randomInt == 3) {
            to_return = level3;
        }
        if (randomInt == 4) {
            to_return = level4;
        }
        if (randomInt == 5) {
            to_return = level5;
        }
        return to_return;
    }

    private GameObject selectNext(int randomInt) {
        GameObject to_return = null;
        if (randomInt == 1) {
            to_return = level2;
        }
        if (randomInt == 2) {
            to_return = level3;
        }
        if (randomInt == 3) {
            to_return = level4;
        }
        if (randomInt == 4) {
            to_return = level5;
        }
        if (randomInt == 5) {
            to_return = level1;
        }
        return to_return;
    }
}
