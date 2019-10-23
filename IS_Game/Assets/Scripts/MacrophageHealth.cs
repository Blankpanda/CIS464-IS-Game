using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacrophageHealth : MonoBehaviour
{
    public GameObject enemy;
    public int health = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(health == 0)
        {
            VirusBehavior.targetList.Remove(this.transform);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Virus")
        {
            Destroy(collision.gameObject);
            health -= 1;
        }
    }
}
