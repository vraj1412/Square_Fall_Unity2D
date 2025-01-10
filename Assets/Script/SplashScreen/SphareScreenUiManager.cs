using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SphareScreenUiManager : MonoBehaviour
{
    [Header("SettingPopUp")]
    public Transform SettingPopUp_MainBG;
    public Image SettingPopUp_AlphaBG;
    public GameObject SettingPopUp_MainParent;



    [Space]
    [Header("Slider")]
    public Slider SoundSlider;
    public Slider MusicSlider;
    [Space]
    [Header("SoundAndMusic MuteParent")]
    public Image SoundImage;
    public Image MusicImage;
    [Space]
    [Header("SoundAndMusic ImageSprite")]
    public Sprite SoundSprite;
    public Sprite MusicSprite;
    public Sprite MuteSoundSprite;
    public Sprite MuteMusicSprite;
    [Space]
    [Header("Text")]
    public TextMeshProUGUI HighScore;

    public Button settingBtn;

    private float temp;


    public SoundAndMusicManager Ref_SoundAndMusicManager;



    public void Start()
    {
        Ref_SoundAndMusicManager = SoundAndMusicManager.instance;

        SoundSlider.value = StaticData.Sound;
        MusicSlider.value = StaticData.Music;

        SetSoundAndMusicValue();
        Ref_SoundAndMusicManager.PlayMusic(Ref_SoundAndMusicManager.BgMusic_Clip);

        settingBtn.onClick.AddListener(OpenSetting);
        
    }

    #region SettingPopUP Open Close
    public void OpenSetting()
    {
        SettingPopUPAnimation(true);
    }
    public void CloseSetting()
    {
        SettingPopUPAnimation(false);
    }

    #endregion

    #region Sound And Music Function
    public void Sound_Slidar()
    {
        StaticData.Sound = SoundSlider.value;

        Ref_SoundAndMusicManager.SetSound_Volume(SoundSlider.value);
        if (StaticData.Sound == 0)

        {

            SoundMute(true);
        }
        else
        {
            SoundMute(false);
        }
    }

    public void Music_Slidar()
    {
        StaticData.Music = MusicSlider.value;
        Ref_SoundAndMusicManager.SetMusic_Volume(MusicSlider.value);

        if (StaticData.Music == 0)
        {

            MusicMute(true);
        }
        else
        {
            MusicMute(false);
        }
    }

    public void Music_Icon()
    {
        if (StaticData.MuteMusic == 0)
        {
            MusicMute(true);
        }
        else
        {
            MusicMute(false);
        }
    }

    public void Sound_Icon()
    {
        if (StaticData.MuteSound == 0)
        {
            SoundMute(true);
        }
        else
        {
            SoundMute(false);
        }

    }

    public void SoundMute(bool mute)
    {

        if (mute)
        {
            StaticData.MuteSound = 1;
            SoundImage.sprite = MuteSoundSprite;
            Ref_SoundAndMusicManager.SoundMute(true);
            SoundSlider.value = 0;
        }
        else
        {
            StaticData.MuteSound = 0;
            SoundImage.sprite = SoundSprite;
            Ref_SoundAndMusicManager.SoundMute(false);
        }
    }

    public void MusicMute(bool mute)
    {

        if (mute)
        {
            //temp = MusicSlider.value;
            StaticData.MuteMusic = 1;
            MusicImage.sprite = MuteMusicSprite;
            Ref_SoundAndMusicManager.MuiscMute(true);
            MusicSlider.value = 0;

        }
        else
        {
            //MusicSlider.value = temp;
            StaticData.MuteMusic = 0;
            MusicImage.sprite = MusicSprite;
            Ref_SoundAndMusicManager.MuiscMute(false);

        }
    }

    public void SetSoundAndMusicValue()
    {

        SoundMute(StaticData.MuteSound != 0);
        MusicMute(StaticData.MuteMusic != 0);


    }
    #endregion


    public void HighScoreSet(int Score)
    {
        HighScore.text= Score.ToString();
    }

    public void SettingPopUPAnimation(bool IsOpen)
    {
        if(IsOpen)
        {
            SettingPopUp_MainParent.SetActive(true);
        }
        SettingPopUp_AlphaBG.DOFade(IsOpen ? 0.8f:0 , 0.1f).From(IsOpen ? 0:0.8f );
        SettingPopUp_MainBG.transform.DOScale(IsOpen ? Vector3.one:Vector3.zero, 0.2f).From(IsOpen ? Vector3.zero:Vector3.one)
            .SetEase(IsOpen ? Ease.OutBack :Ease.InBack)
            .OnComplete(()=>
            {
                if (!IsOpen)
                {
                    SettingPopUp_MainParent.SetActive(false);
                }

            });
    }
}
