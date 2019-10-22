using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionHandler : MonoBehaviour
{

    [SerializeField]
    public bool selected = false;

    [SerializeField]
    public bool activeSelection;

    [SerializeField]
    Sprite selectedSprite, normalSprite;
    

    private void OnMouseDown()
    { 
        SelectionHandler.ClearActiveSelections();
        this.activeSelection = true; // This will be important to display an interface options pertaining to a specific unit when it's selected 
        ToggleSprite(); 
        PrintSelectedObjects();
    }

    private void Selected()
    {
        this.selected = true;
    }

    private void ToggleSprite()
    {
        if (this.activeSelection)
        {
            GetComponent<SpriteRenderer>().sprite = selectedSprite;
        } else
        {
            GetComponent<SpriteRenderer>().sprite = normalSprite; 
        }
         
    }

    // DEBUG:
    private void PrintSelectedObjects()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("PlayerUnit");
        Debug.Log("Selected objects: ");
        foreach (var gameobj in gameObjects)
        {
            SelectionHandler handler = (SelectionHandler)gameobj.GetComponent("SelectionHandler");
            if (handler.selected == true)
            {
                Debug.Log(gameobj.ToString() + " -> " + handler.selected.ToString());
            }
        }
    }

    // Static helper classes 

    // Set the active selection variable to false for all units 
    public static void ClearActiveSelections()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("PlayerUnit");
        foreach (var gameobj in gameObjects)
        {
            SelectionHandler handler = (SelectionHandler)gameobj.GetComponent("SelectionHandler");
            handler.activeSelection = false;
            handler.ToggleSprite();
        }
    }

    // Clear selection from all units, probably not the best software development standard to have this function here :-)
    public static void ClearSelections()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("PlayerUnit");
        foreach (var gameobj in gameObjects)
        {
            SelectionHandler handler = (SelectionHandler)gameobj.GetComponent("SelectionHandler");
            handler.selected = false;
        }
    }

}
