using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField]
    GameObject spawnable;
    public float offset = 3;

    public string buildingName;

    public void spawnUnit()
    {
        GameObject newUnit = Instantiate(spawnable);

        string unitName = newUnit.name;
        int cost = ResourceManager.MatchNameToPrice(unitName);

        var mapObj = GameObject.FindGameObjectWithTag("Map");
        var resourceManager = mapObj.GetComponent<ResourceManager>();

        if (resourceManager.totalMarrow >= cost)
        {
            resourceManager.totalMarrow -= cost;
            newUnit.transform.position = new Vector3(transform.position.x, transform.position.y - offset, transform.position.z);
        } 

    }
}
