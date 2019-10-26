using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingCell : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        //If T-Cell collides with another player unit, set healing to true
        if(collision.tag == "PlayerUnit")
        {
            collision.GetComponent<CellHealth>().healing = true;
        }
    }
}
