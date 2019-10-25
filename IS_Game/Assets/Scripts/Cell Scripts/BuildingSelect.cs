using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Building))]


public class BuildingSelect : MonoBehaviour
{
    public bool selected = false;

    void OnMouseDown()
    {
        selected = true;
        BuildingManger.currentBuilding = GetComponent<Building>();
        BuildingManger.buildingName = GetComponent<Building>().buildingName;
    }
}
