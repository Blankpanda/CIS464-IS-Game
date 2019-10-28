using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int totalMarrow = 100;
    public int marrowPerTick = 100;
    public float time = 0.0f;
    public float marrowRate = 0.9f;


    public enum UnitPrices
    {
        MACROPHAGE = 100,
        T_CELL = 120,
        B_CELL = 150,
        DENDRITIC = 300,
        NEUTROPHIL = 500,
    }


    // Every unit should inherit from some base IUnit interface with a health and cost property instead of having this script talk to Building.cs 
    // but in the interest of time its going to be hacked like this. forgive me 
    public static int MatchNameToPrice(string unitName) {
        unitName = unitName.ToUpper();
        if (unitName.Contains("MACROPHAGE"))
        {
            return (int)UnitPrices.MACROPHAGE;
        }
        else if (unitName.Contains("T-CELL"))
        {
            return (int)UnitPrices.T_CELL;
        }
        else if (unitName.Contains("B-CELL"))
        {
            return (int)UnitPrices.B_CELL;
        }
        else if (unitName.Contains("DENDRITIC"))
        {
            return (int)UnitPrices.DENDRITIC;
        }
        else if (unitName.Contains("NEUTROPHIL"))
        {
            return (int)UnitPrices.NEUTROPHIL;
        } else
        {
            return 0; 
        }
    }


    public void Update()
    {

    }

    public void Start()
    {
        InvokeRepeating("MarrowTick", 1.0f, 5.0f); 
    }

    void MarrowTick()
    {
        totalMarrow += marrowPerTick; 
    }

    public void gameOver()
    {
        Debug.Log("GameOver");
    }
}
