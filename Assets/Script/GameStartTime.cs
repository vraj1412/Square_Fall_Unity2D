using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStartTime : MonoBehaviour
{
    public int startTime=3;
    public TextMeshProUGUI textMeshProUGUI;
    
  
    void Awake()
    {
      StartCoroutine(StartTime());
        
    }
    
    public IEnumerator StartTime()
    {

        for (int i = startTime; i >= 0; i--)
        {
        
                yield return new WaitForSeconds(1);
        
            if (i == 0)
                    {
                        textMeshProUGUI.text = "Go!!";

                    }else
                    textMeshProUGUI.text = i.ToString();


                }
    }   
}
