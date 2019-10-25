using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    public GameObject enemy;
    public float killRate;
    float currentTime;
    void Start ()
    {

	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Virus" || collision.tag == "Infecting Virus")
        {
            enemy = collision.gameObject;
        }
    }
    void Update ()
    {
		if(enemy != null)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0) //reached the end of the timer
            {
                //Kill virus
                Destroy(enemy);
                currentTime = killRate;
            }
        }
	}
}
