using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int totalMarrow = 1000;
    public int marrowPerTick = 20;
    public float time = 0.0f;
    public float marrowRate = 5.0f;
    public static bool debugMode = false;


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
        else if (unitName.Contains("T-CELLS"))
        {
            return (int)UnitPrices.T_CELL;
        }
        else if (unitName.Contains("B-CELL"))
        {
            return (int)UnitPrices.B_CELL;
        }
        else if (unitName.Contains("DENDRITIC CELL"))
        {
            return (int)UnitPrices.DENDRITIC;
        }
        else if (unitName.Contains("NEUTROPHIL"))
        {
            return (int)UnitPrices.NEUTROPHIL;
        } else
        {
            return 1000; 
        }
    }


    public void Update()
    {

    }

    public void Start()
    {
        totalMarrow = 1000; 
        InvokeRepeating("MarrowTick", 1.0f, 5.0f); 
    }

    void MarrowTick()
    {
        // Get a count of bcells 
        var units = GameObject.FindGameObjectsWithTag("PlayerUnit");
        int dCellCount = 1;
        foreach (var cell in units)
        {
            if (cell.name.ToUpper().Contains("DENDRITIC"))
            {
               dCellCount += 1; 
            }
        }

        Debug.Log(dCellCount.ToString());
  
        if (debugMode)
        {
            totalMarrow = 9999999; 
        } else
        {
            totalMarrow += (marrowPerTick * dCellCount);
        }

    }

    public void gameOver()
    {
        Debug.Log("GameOver");
    }
}
