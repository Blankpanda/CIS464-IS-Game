using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //keep track of health
    public int health = 100;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Virus")
        {
            health -= 1;
            Destroy(collision.gameObject);
        }
    }
    //end game
    void Update()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene("Start_Menu");
        }
    }
}
