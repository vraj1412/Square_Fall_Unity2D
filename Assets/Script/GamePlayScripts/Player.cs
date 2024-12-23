using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Transform PlayerTransform;
    public float speed;
    public Transform StartPoint;
    public Transform EndPoint;
    public int direction = 1;


    public void Update()
    {
        MovePlayer();
        MovePlayerByTouch();

    }
   
    Vector2 CurrentMovmentTarget()
    {
        if (direction == 1)
        {
            return StartPoint.position;
        }
        else
        {
            return EndPoint.position;
        }
    }
    public void MovePlayer()
    {
        Vector2 target = CurrentMovmentTarget();
        PlayerTransform.position = Vector2.MoveTowards(PlayerTransform.position, target, speed * Time.deltaTime);
        float distance = (target - (Vector2)PlayerTransform.position).magnitude;

        if (distance <= 0.1f)
        {
            direction *= -1;
        }
    }

    public void MovePlayerByTouch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            direction *= -1;
        }

    }
  
}
