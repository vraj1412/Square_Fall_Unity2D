using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphareScreenBtnManager : MonoBehaviour
{
    public SphareScreenUiManager Ref_SplashScreenUiManagar;
    public SoundAndMusicManager soundandmusic;

    

    public void Start()
    {
        soundandmusic = SoundAndMusicManager.instance;
    }
    public void Button_Control(string button)
    {
        soundandmusic.PlaySound(Ref_SplashScreenUiManagar.Button_Clip);

        switch (button)
        {
            case "start":
                SceneManager.LoadSceneAsync(1,LoadSceneMode.Additive);
                break;
            case "Open_Setting":
                setting_popup_open();
                break;
            case "Close_Setting":
                setting_popup_close();
                break;
            case "Sound":
                Ref_SplashScreenUiManagar.Sound_Slidar();
                break;
            case "Music":
                Ref_SplashScreenUiManagar.Music_Slidar();
                break;
            case "Sound_Mute":
                Ref_SplashScreenUiManagar.Sound_Icon();
                break;
            case "Music_Mute":
                Ref_SplashScreenUiManagar.Music_Icon();
                break;
        }
    }

    public void setting_popup_open()
    {
        Ref_SplashScreenUiManagar.OpenSetting();
    }
    public void setting_popup_close()
    {
        Ref_SplashScreenUiManagar.CloseSetting();
    }
}
