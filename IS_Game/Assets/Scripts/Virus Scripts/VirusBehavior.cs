using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusBehavior : MonoBehaviour
{
    //how fast the virus moves
    public float speed;
    //list of targets to attack
    public static List<Transform> targetList = new List<Transform>();
    public Transform currentTarget;
    float distance = 0;

    void Update()
    {
        assignCurrentTarget();
        moveToCurrentTarget();
    }
    void assignCurrentTarget()
    {
        foreach (Transform possibleTarget in targetList)
        {
            //find the closest target
            if (currentTarget != null)
            {
                if (Vector2.Distance(possibleTarget.localPosition, this.transform.localPosition) <= distance)
                {
                    distance = Vector2.Distance(possibleTarget.localPosition, this.transform.localPosition);
                    currentTarget = possibleTarget;
                }
            }
            else
            {
                currentTarget = possibleTarget;
                distance = Vector2.Distance(currentTarget.localPosition, this.transform.localPosition);
            }
        }
    }
    //attack the target
    void moveToCurrentTarget()
    {
        if(currentTarget != null)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, currentTarget.transform.position, speed*Time.deltaTime);
        }
    }
}
