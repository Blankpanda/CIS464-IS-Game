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
        if (isUnitDisplay)
        {
            Debug.Log(isUnitDisplay);
            Debug.Log(SelectedUnit.name.ToString());
            var selectedUnitHealthComponent = SelectedUnit.GetComponent<MacrophageHealth>();
            var selectedUnitTextureComponent = SelectedUnit.GetComponent<SpriteRenderer>();


            GUI.Box(new Rect(Screen.width - 110, Screen.height - 140, 140, 200), "");
            GUI.Label(new Rect(Screen.width - 100, Screen.height - 130, 100, 50), SelectedUnit.name.ToString());
            GUI.DrawTexture(new Rect(Screen.width - 90, Screen.height - 95, 65, 65), selectedUnitTextureComponent.sprite.texture); 
            GUI.Label(new Rect(Screen.width - 100, Screen.height - 30, 200, 200), "Health: " +  selectedUnitHealthComponent.health.ToString());
        }
        else if (isBuildingDisplay)
        {
            throw new NotImplementedException();
        }
    }
}
