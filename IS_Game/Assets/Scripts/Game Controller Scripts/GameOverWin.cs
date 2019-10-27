using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverWin : MonoBehaviour
{
    //if destoryed by dendritic cell, end game and bging to start menu
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerUnit")
        {
            SceneManager.LoadScene("Start_Menu");
        }
    }
}
