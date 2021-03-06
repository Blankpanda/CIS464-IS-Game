﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToHealthyNodeList : MonoBehaviour
{
    //node attribuest
    public int health = 3;
    private bool isInfected = false;
    public Color infectedColor;
    public Color healthyColor;

    //add to targtet list of potentially infectable nodes
    void Start()
    {
        InfectingVirusBehavior.targetList.Add(this.transform);
    }

    //if infected by a virus, become an infected node.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "InfectingVirus")
        {
            if(health == 0)
            {
                InfectingVirusBehavior.targetList.Remove(this.transform);
                GetComponent<SpriteRenderer>().color = infectedColor;
                GetComponent<VirusSpawner>().enabled = true;
                GetComponent<AddToHealthyNodeList>().enabled = false;
                isInfected = true;
            }
            else
            {
                Destroy(collision.gameObject);
                health--;
            }
        }
        //if hit by a player, and is infected, destory the building
        if(collision.transform.tag == "PlayerUnit" && isInfected)
        {
            InfectingVirusBehavior.targetList.Remove(this.transform);
            VirusBehavior.targetList.Remove(this.transform);
            InfectingVirusBehavior.targetList.Remove(collision.transform);
            VirusBehavior.targetList.Remove(collision.transform);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
