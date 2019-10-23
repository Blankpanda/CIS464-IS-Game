using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignToTargetList : MonoBehaviour
{
    
	void Start ()
    {
        VirusBehavior.targetList.Add(this.transform);
	}
	
	void Update ()
    {
		
	}
    public void buildingDestroyed()
    {
        VirusBehavior.targetList.Remove(this.transform);
    }
}
