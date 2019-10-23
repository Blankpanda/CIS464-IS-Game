using UnityEngine;

public class CameraController : MonoBehaviour
{
    //speed of the camera movement
    public float panSpeed = 20f;
    //how close to the border the mouse has to be to pan
    public float panBorderThickness = 10f;
    //limit how far the camera can pan
    public Vector2 panLimit;
    //In 2D, zoom is done by changing the camera size
    public float zoomSize = 10;

	void Update ()
    {
        //current position of the camera
        Vector3 pos = transform.position;

        //get input on what direction to move
        if (Input.GetKey("up") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("down") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("right") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("left") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        //get input on when to zoom
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            zoomSize -= 1;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            zoomSize += 1;
        }
        //change size of camera based on zoom
        GetComponent<Camera>().orthographicSize = zoomSize;

        //restirct camera movement
        zoomSize = Mathf.Clamp(zoomSize, 5, 25);
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, - panLimit.y, panLimit.y);

        //update camera position
        transform.position = pos;
	}
}
