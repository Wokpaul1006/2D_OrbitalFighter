using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSC : MonoBehaviour
{
    [SerializeField] Image themeLoud, themeMute, sfxLoud, sfxMute;
    [HideInInspector] SoundMN soundSFX;
    [HideInInspector] ThemeMN soundTheme;
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] DataSC dataCtr;

    [Header("Variables")]
    private bool isSoundTheme; //manage theme of the game
    private bool isSFX; //manage effect of the gameplay such like shooting sound or exploding sound
    private bool isVibrate; //manage vibrate of game when exploision init
    public int sfxState, themeState;
    void Start() => OnStartGame();
    void OnStartGame()
    {
        SettingStart();
        CheckSoundinit();
    }
    private void SettingStart()
    {
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        dataCtr = GameObject.Find("OBJ_DataCtr").GetComponent<DataSC>();
        soundSFX = GameObject.Find("OBJ_SoundSFX").GetComponent<SoundMN>();
        soundTheme = GameObject.Find("OBJ_SoundTheme").GetComponent<ThemeMN>();
        dataCtr.CheckSoundState();
    }

    #region Sound Handler
    public void OnSoundClick()
    {
        if(isSFX == true) 
        {
            //Case of turn off sound
            isSoundTheme = false;
            sfxState = 0;
            sfxLoud.gameObject.SetActive(false);
            sfxMute.gameObject.SetActive(true);
            soundSFX.OnMuteSFX();

        }
        else
        {
            //Case of turn on sound
            isSoundTheme = true;
            sfxState = 1;
            sfxLoud.gameObject.SetActive(true);
            sfxMute.gameObject.SetActive(false);
            soundSFX.OnAllowSFX();
        }
        dataCtr.UpdateSoundState(sfxState, themeState);
    }
    public void OnThemClick()
    {
        if (isSoundTheme == true)
        {
            //Case of turn off sound
            isSoundTheme = false;
            themeState = 0;
            themeLoud.gameObject.SetActive(false);
            themeMute.gameObject.SetActive(true);
            soundTheme.OnMuteTheme();
        }
        else
        {
            //Case of turn on sound
            isSoundTheme = true;
            themeState = 1;
            themeLoud.gameObject.SetActive(true);
            themeMute.gameObject.SetActive(false);
            soundTheme.OnPlayTheme();
        }
        dataCtr.UpdateSoundState(sfxState, themeState);
    }
    public void CheckSoundinit()
    {
        if (sfxState == 1) soundSFX.OnAllowSFX();
        else if (sfxState == 0) soundSFX.OnMuteSFX();

        if (themeState == 0) soundTheme.OnPlayTheme();
        else if (themeState == 1) soundTheme.OnMuteTheme();
    }
    #endregion
    public void OnVibrateClick()
    {
        if(isVibrate == true) { isVibrate = false; }
        else 
        {
            isVibrate = true;
            //Handheld.Vibrate();
        }
    }
    public void OnLangueClick()
    {
        //Change langues function
    }
    public void OnProfileClick() => genCtr.OnShowInforPanel();
    public void OnFBClick()
    {
        //Log in by Facebook
    }
    public void OnGoogleClick()
    {
        //Login by Gmail
    }
    public void ToPrivacyPolicy() => Application.OpenURL("");
    public void ToPlayStore() => Application.OpenURL("https://play.google.com/store/apps/developer?id=Sadek+Games+Studio");
    public void OnExitClick() => Application.Quit(0);
}
