using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting.Antlr3.Runtime;
public class GamePlayUiManager : MonoBehaviour
{

    //  public static GamePlayUiManager instance;
    // Start is called before the first frame update
    #region Varibal
    [Header("Ref_Scrpit")]
    public GamePlay Ref_GamePlay;

    [Header("Audio_Clip")]
    public AudioClip BG_clip;
    public AudioClip Click_Clip;
    
    [Space]
    [Header("Sprite")]
    public Sprite Obstacal_Sprite;
    public Sprite UnObsatacal_Sprite;


    [Space]
    [Header("GameOver_PopUp")]
    public GameObject GameOverPopUP;
    public TextMeshProUGUI ScoreText;

   

    [Space]
    [Header("Sound Componat")]
    public Slider Sound_Slider;
    public Image Sound_ImageSorce;
    public Sprite SoundOn_Sprite;
    public Sprite SoundOff_Sprite;
    [Space]
    [Header("Music Componat")]
    public Slider Music_Slider;
    public Image Music_ImageSorce;
    public Sprite MusicOn_Sprite;
    public Sprite MusicOff_Sprite;

    public Button settingBtn;

    [Header("SettingPopUp")]
    public Transform SettingPopUp_MainBG;
    public Image SettingPopUp_AlphaBG;
    public GameObject SettingPopUp_MainParent;
    public GraphicRaycaster Setting_GraphicRaycaster;


    [Header("GameOverPopUp")]
    public Transform GameOverPopUp_MainBG;
    public Image GameOverPopUp_AlphaBG;
    public GameObject GameOverPopUp_MainParent;
    public GraphicRaycaster GameOver_GraphicRaycaster;
    [Space]
    [Header("Score")]
    public TextMeshProUGUI Score_Text;
    #endregion

    public void Start()
    {
        GameOverPopUp_Close();
        CloseSetting();

        settingBtn.onClick.AddListener(OpenSetting);
    }

    #region GameOver_PopUP Function
    public void GameOverPopUp_Open()
    {
        ScoreText.text = (StaticData.Score).ToString();
        GameOverPopUPAnimation(true);


    }

    public void GameOverPopUp_Close()
    {
        GameOverPopUPAnimation(false);
    }
    #endregion


    #region Sound,Music Clip_Function
    public void Play_BGMusic()
    {
        Ref_GamePlay.Ref_SoundAndMusicManager.PlayMusic(BG_clip);
    }

    public void Play_TouchSound()
    {
        Ref_GamePlay.Ref_SoundAndMusicManager.PlaySound(Click_Clip);
    }

   
    #endregion

    





    public void OpenSetting()
    {

        Sound_Slider.value = StaticData.Sound;
        Music_Slider.value = StaticData.Music;

        SetSoundAndMusicValue();
        Ref_GamePlay.Ref_SoundAndMusicManager.PlayMusic(Ref_GamePlay.Ref_SoundAndMusicManager.BgMusic_Clip);

      //  settingBtn.onClick.AddListener(OpenSetting);

      
    }

    public void SettingPopUpOpen()
    {
        SettingPopUPAnimation(true);
    }

    public void CloseSetting()
    {
        SettingPopUPAnimation(false);
    }


    public void ScoreDispaly(int Score)
    {
        Score_Text.text = Score.ToString();
    }


    public void SettingPopUPAnimation(bool IsOpen)
    {
        if (IsOpen)
        {
            Setting_GraphicRaycaster.enabled = true;
            SettingPopUp_MainParent.SetActive(true);
        }
        SettingPopUp_AlphaBG.DOFade(IsOpen ? 0.8f : 0, 0.1f).From(IsOpen ? 0 : 0.8f);
        SettingPopUp_MainBG.transform.DOScale(IsOpen ? Vector3.one : Vector3.zero, 0.2f).From(IsOpen ? Vector3.zero : Vector3.one)
            .SetEase(IsOpen ? Ease.OutBack : Ease.InBack)
            .OnComplete(() =>
            {
                if (!IsOpen)
                {
                    Setting_GraphicRaycaster.enabled = false;
                    SettingPopUp_MainParent.SetActive(false);
                }

            });
    }

    public void GameOverPopUPAnimation(bool IsOpen)
    {
        if (IsOpen)
        {
            GameOver_GraphicRaycaster.enabled = true;
            GameOverPopUp_MainParent.SetActive(true);
        }
        GameOverPopUp_AlphaBG.DOFade(IsOpen ? 0.8f : 0, 0.1f).From(IsOpen ? 0 : 0.8f);
        GameOverPopUp_MainBG.transform.DOScale(IsOpen ? Vector3.one : Vector3.zero, 0.2f).From(IsOpen ? Vector3.zero : Vector3.one)
            .SetEase(IsOpen ? Ease.OutBack : Ease.InBack)
            .OnComplete(() =>
            {
                if (!IsOpen)
                {
                    GameOver_GraphicRaycaster.enabled = false;
                    SettingPopUp_MainParent.SetActive(false);
                }

            });
    }





    #region Sound And Music Function
    public void Sound_Slidar()
    {
        StaticData.Sound = Sound_Slider.value;

        Ref_GamePlay.Ref_SoundAndMusicManager.SetSound_Volume(Sound_Slider.value);
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
        StaticData.Music = Music_Slider.value;
        Ref_GamePlay.Ref_SoundAndMusicManager.SetMusic_Volume(Music_Slider.value);

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
            Sound_ImageSorce.sprite = SoundOff_Sprite;
            Ref_GamePlay.Ref_SoundAndMusicManager.SoundMute(true);
            Sound_Slider.value = 0;
        }
        else
        {
            StaticData.MuteSound = 0;
            Sound_ImageSorce.sprite = SoundOn_Sprite;
            Ref_GamePlay.Ref_SoundAndMusicManager.SoundMute(false);
        }
    }

    public void MusicMute(bool mute)
    {

        if (mute)
        {
            //temp = MusicSlider.value;
            StaticData.MuteMusic = 1;
            Music_ImageSorce.sprite = MusicOff_Sprite;
            Ref_GamePlay.Ref_SoundAndMusicManager.MuiscMute(true);
            Music_Slider.value = 0;

        }
        else
        {
            //MusicSlider.value = temp;
            StaticData.MuteMusic = 0;
            Music_ImageSorce.sprite = MusicOn_Sprite;
            Ref_GamePlay.Ref_SoundAndMusicManager.MuiscMute(false);

        }
    }

    public void SetSoundAndMusicValue()
    {

        SoundMute(StaticData.MuteSound != 0);
        MusicMute(StaticData.MuteMusic != 0);


    }
}
#endregion