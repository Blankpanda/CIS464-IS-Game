using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryBehavior : MonoBehaviour
{
    //how fast the virus moves
    public float speed;
    //where it moves towards
    public Transform target;

    //get object to move towards
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("B-Cell").GetComponent<Transform>();
	}
    //Move towards object
	void Update ()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
	}
}
