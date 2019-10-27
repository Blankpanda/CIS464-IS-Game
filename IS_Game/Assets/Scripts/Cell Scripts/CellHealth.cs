using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHealth : MonoBehaviour
{
    //variables
    public GameObject enemy;
    public float maxHealth = 100;
    public float currentHealth;

    //state for healing
    public bool healing = false;
    public float healingRate = 1;

    //set the current health to the maximum health at start
    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if health is at 0, destroy the game object
        if(currentHealth <= 0)
        {
            VirusBehavior.targetList.Remove(this.transform);
            Destroy(gameObject);
        }
        //if hit by a virus, kill the virus and reduce health by 1
        if (collision.gameObject.tag == "Virus" || collision.gameObject.tag == "InfectingVirus")
        {
            Destroy(collision.gameObject);
            currentHealth -= 1;
        }
        //if hit by a helper T cell, begin healing
        if(collision.gameObject.GetComponent<HealingCell>() != null)
        {
            healing = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<HealingCell>() != null)
        {
            healing = false;
        }
    }

    //check to see if you are healing
    void Update()
    {
        if(healing)
        {
            heal(healingRate);
        }
    }

    //healing function
    public void heal(float healingRate)
    {
        if(currentHealth < maxHealth)
        {
            currentHealth = currentHealth + (healingRate * Time.deltaTime);
        }
        else
        {
            healing = false;
        }
    }
}