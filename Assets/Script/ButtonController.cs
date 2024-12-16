using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    public  void Buttonclick()
    {
        Debug.Log("Start Btn CLick");

        SceneManager.LoadScene("Dashboard");


        
    }
}
