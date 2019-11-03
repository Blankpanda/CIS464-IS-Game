using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Here be dragons, thou art forewarned 
 
public class ClickToMove : MonoBehaviour
{

    public float speed;
    private bool move;
    private Vector3 target;

    private void Awake()
    {
        this.move = false; 
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1)) // Right click, move the unit 
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = this.gameObject.transform.position.z;
            MoveObject();
        }
        else if (Input.GetMouseButtonDown(0)) // Left click, determine if its a selection or deselection 
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2d = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2d, Vector2.zero);


            if (hit.collider == null || !(hit.collider.tag == "PlayerUnit" || hit.collider.tag == "Building" || hit.collider.tag == "GameButton"))
            {

                //Debug.Log(hit.collider.ToString());
                SelectionHandler.ClearActiveSelections();
                SelectionHandler.ClearSelections();
                SelectionHandler.SelectedObjects.Clear();
                
                UiManager.isBuildingDisplay = false;
                UiManager.isUnitDisplay = false;

                //BuildingManager.DeselectCurrentBuilding();
            }
        }
    }

    void MoveObject()
    {
        SelectionHandler handler = (SelectionHandler)this.gameObject.GetComponent("SelectionHandler");
        bool isSelected = handler.selected || handler.activeSelection;

        if (isSelected)
        {
            //Debug.Log("Starting move coruitine"); 
            StartCoroutine(Move(this.gameObject.transform, this.gameObject.transform.position, target)); 
        }

    }

    IEnumerator Move(Transform tf, Vector3 from, Vector3 to)
    {
        float step = (speed / (from-to).magnitude) * Time.fixedDeltaTime; 
        float l = 0;        
        while (l <= 1.0f)
        {
            // Debug.Log("Move tick");
            l += step;
            tf.position = Vector3.Lerp(from, to, l); //Vector3.MoveTowards(, target, l);
            
            yield return new WaitForEndOfFrame();
        }
        //transform.position = Vector3.MoveTowards(transform.position, target,);
    }
}

