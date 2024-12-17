using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphareScreenBtnManager : MonoBehaviour
{
    public void Button_Control(string button)
    {
        switch (button)
        {
            case "start":
                SceneManager.LoadScene(1);
                break;
        }


    }
}
