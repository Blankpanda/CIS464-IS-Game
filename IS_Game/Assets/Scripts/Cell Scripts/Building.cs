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
        int cost = ResourceManager.MatchNameToPrice(buildingName);

        var mapObj = GameObject.FindGameObjectWithTag("Map");
        var resourceManager = mapObj.GetComponent<ResourceManager>();

        if (resourceManager.totalMarrow >= cost)
        {
            GameObject newUnit = Instantiate(spawnable);
            string unitName = newUnit.name;
            resourceManager.totalMarrow -= cost;
            newUnit.transform.position = new Vector3(transform.position.x, transform.position.y - offset, transform.position.z);
        } 

    }
}
