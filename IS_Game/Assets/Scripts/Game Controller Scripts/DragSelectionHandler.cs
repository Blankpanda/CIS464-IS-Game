using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSelectionHandler : MonoBehaviour {

    private bool selecting = false;
    Vector3 mouseStart; 
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            selecting = true;
            mouseStart = Input.mousePosition; 
        }

        if (Input.GetMouseButtonUp(0))
        {
            selecting = false;
            Bounds bounds = GetSelectionBounds(Camera.main, mouseStart, Input.mousePosition);
            SelectionHandler.SelectWithinBounds(bounds); 
        }
	}

    public static Rect GetRect(Vector3 pos1, Vector3 pos2)
    {
        pos1.y = Screen.height - pos1.y;
        pos2.y = Screen.height - pos2.y;

        var topLeft = Vector3.Min(pos1, pos2);
        var bottomRight = Vector3.Max(pos1, pos2); 

        return Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
    }

    public static void DrawSelectionRect(Rect rectangle, Color color)
    {
        //// Texture
        Texture2D whiteBox = new Texture2D(1, 1);
        whiteBox.SetPixel(0, 0, Color.white);
        whiteBox.Apply();

        GUI.color = color;
        GUI.DrawTexture(rectangle, whiteBox);
        GUI.color = Color.white;
    }

    private void OnGUI()
    {
        if (selecting)
        {
            var SelectionRectangle = GetRect(mouseStart, Input.mousePosition); 
            DrawSelectionRect(SelectionRectangle, Color.green);
        }
    }

    private Bounds GetSelectionBounds(Camera camera, Vector3 start, Vector3 stop)
    {
        var v1 = Camera.main.ScreenToViewportPoint(start);
        var v2 = Camera.main.ScreenToViewportPoint(stop);

        var min = Vector3.Min(v1, v2);
        var max = Vector3.Max(v1, v2);

        min.z = camera.nearClipPlane;
        max.z = camera.farClipPlane; 

        Bounds bounds = new Bounds();
        bounds.SetMinMax(min, max);

        //Debug.Log(bounds.ToString());

        return bounds; 
    }
}
