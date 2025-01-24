using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphareScreenManager : MonoBehaviour
{
    public GoogleAds GoogleAds;
    public SphareScreenUiManager Ref_SphareScreenUiManager;
    // Start is called before the first frame update
    void Start()
    {
        GoogleAds.ShowAppOpenAd();
        Ref_SphareScreenUiManager.HighScoreSet(StaticData.HighScore);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
