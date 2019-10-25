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
        newUnit.transform.position = new Vector3(transform.position.x, transform.position.y - offset, transform.position.z);
    }
}
