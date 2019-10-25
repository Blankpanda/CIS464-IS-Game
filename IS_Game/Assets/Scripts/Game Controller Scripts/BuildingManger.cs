using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManger : MonoBehaviour
{

    public static Building currentBuilding;
    public static string buildingName;
    public Text buildingText;
    public GameObject buildButton;
    private void Update()
    {
        buildButton.SetActive(currentBuilding);
        if (currentBuilding != null)
        {
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
}