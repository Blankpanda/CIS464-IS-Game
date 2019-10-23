using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectingVirusBehavior : MonoBehaviour
{
    //how fast the virus moves
    public float speed;
    public static List<Transform> targetList = new List<Transform>();
    public Transform currentTarget;
    float distance = 0;

    void Start()
    {

    }

    void Update()
    {
        assignCurrentTarget();
        moveToCurrentTarget();
    }
    void assignCurrentTarget()
    {
        foreach (Transform possibleTarget in targetList)
        {
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
    void moveToCurrentTarget()
    {
        if (currentTarget != null)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, currentTarget.transform.position, speed * Time.deltaTime);
        }
    }
}
