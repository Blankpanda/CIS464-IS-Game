using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{

    public static Building currentBuilding;
    public static string buildingName;
    public Text buildingText;
    public GameObject buildButton;

    private void Update()
    {
        if (currentBuilding == null)
        {
            buildButton.SetActive(false);
        }
        else
        {
            buildButton.SetActive(true);
            buildingText.text = buildingName;
        }
    }

    public void spawnBuildingSpawnable()
    {
        if (currentBuilding != null)
        {
            currentBuilding.spawnUnit();
        }
    }

    public static void DeselectCurrentBuilding()
    { 
        BuildingManager.currentBuilding = null; 
        //var map = GameObject.FindGameObjectWithTag("Map");
        //var buildingManager = map.GetComponent<BuildingManager 
        //buildingManager.buildButton.SetActive(false);
    }
}