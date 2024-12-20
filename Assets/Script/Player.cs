using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform Tm;
    public float speed;


    void Start()
    {
        
    }

    public void Update()
    {
        //        Debug.Log("Update Call");

        rb.AddForce(new Vector2(speed, 0));
        // Tm.Translate(new Vector3(speed, 0, 0));
    }

    public void MovePlayer()
    {
        
    }


}
