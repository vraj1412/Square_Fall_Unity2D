using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colldar : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
    }

}
