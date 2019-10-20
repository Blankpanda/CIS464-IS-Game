using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour {

    //movement speed
    public float speed;
    //whether or not the object is moving
    public bool move;
    //where the object will move towards
    private Vector3 target;

	// Update is called once per frame
	void Update ()
    {
        //when the mouse is clicked
		if(Input.GetMouseButtonDown(0))
        {

            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            if(move == false)
            {
                move = true;
            }
        }
        if(move == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
	}
}
