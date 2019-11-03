using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// kind of a hacky way to do this but..................
public class UiManager : MonoBehaviour {

    public static bool isUnitDisplay;
    public static bool isBuildingDisplay;

    public static GameObject SelectedUnit; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        ResourceManager resourceObj = gameObject.GetComponent<ResourceManager>();
        int marrowCount = resourceObj.totalMarrow; 
        GUI.Box(new Rect(0, 0, 100, 50), "Marrow");
        GUI.Label(new Rect(20, 20, 100, 50), marrowCount.ToString());


        if (isUnitDisplay)
        {
            //Debug.Log(isUnitDisplay);
            //Debug.Log(SelectedUnit.name.ToString());
            var selectedUnitHealthComponent = SelectedUnit.GetComponent<CellHealth>();
            var selectedUnitTextureComponent = SelectedUnit.GetComponent<SpriteRenderer>();
            

 
            GUI.Box(new Rect(Screen.width - 100, 0, 120, 110), "");
            GUI.Label(new Rect(Screen.width - 90, 5, 100, 50), SelectedUnit.name.ToString());
            GUI.DrawTexture(new Rect(Screen.width - 85, 20, 65, 65), selectedUnitTextureComponent.sprite.texture); 
            GUI.Label(new Rect(Screen.width - 90, 80, 200, 200), "Health: " +  selectedUnitHealthComponent.currentHealth.ToString());
        }
        else if (isBuildingDisplay)
        {
            throw new NotImplementedException();
        }
    }
}
