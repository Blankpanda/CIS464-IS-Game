using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToHealthyNodeList : MonoBehaviour
{
    public int health = 3;
    private bool isInfected = false;
    public Color infectedColor;
    void Start()
    {
        InfectingVirusBehavior.targetList.Add(this.transform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "InfectingVirus")
        {
            if(health == 0)
            {
                InfectingVirusBehavior.targetList.Remove(this.transform);
                isInfected = true;
            }
            else
            {
                Destroy(collision.gameObject);
                health--;
            }
            
        }
    }

    void Update()
    {
        if(isInfected)
        {
            GetComponent<SpriteRenderer>().color = infectedColor;
            GetComponent<VirusSpawner>().enabled = true;
            GetComponent<AddToHealthyNodeList>().enabled = false;
        }
    }
}
