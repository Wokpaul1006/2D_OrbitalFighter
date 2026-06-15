using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class OmniMN : Singleton<OmniMN>
{
    [SerializeField] Text versionTxt;
    [HideInInspector] OptionSC optionPnl;
    [HideInInspector] InfoSC inforPnl;
    [HideInInspector] PauseSC pausePnl;
    [HideInInspector] GameOverSC gameoverPnl;
    [HideInInspector] DataSC dataControl;
    [HideInInspector] SoundMN sfxToPlay;
    [HideInInspector] public int platformType, gameMode;
    [HideInInspector] private int hasPlayed; //Use this variable for check FirstPlay.


    public string toDay;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (Application.platform == RuntimePlatform.Android
            || Application.platform == RuntimePlatform.IPhonePlayer) { platformType = 1; }//Mobile
        else if (Application.platform == RuntimePlatform.WindowsEditor
            || Application.platform == RuntimePlatform.WindowsPlayer
            || Application.platform == RuntimePlatform.WebGLPlayer) { platformType = 2; }//Window & Web
    }
    void Start()
    {
        SettingStart();
        OnCheckPlay();
        toDay = DateTime.Today.Day.ToString();
        versionTxt.text = Application.version.ToString();
    }
    public void OnChangeScene(int sceneOder)
    {
        print("scenOrder = " + sceneOder);
        switch (sceneOder)
        {
            case 0:
                SceneManager.LoadScene("1.Loading");
                break;
            case 1:
                SceneManager.LoadScene("2.Menu");
                gameMode = 0;
                break;
            case 2:
                SceneManager.LoadScene("3.PlayArcade");
                gameMode = 1;
                break;
            case 3:
                SceneManager.LoadScene("4.PlayLevel");
                gameMode = 2;
                break;
        }
    }
    private void SettingStart()
    {
        hasPlayed = PlayerPrefs.GetInt("HasPlayed");
        optionPnl = GameObject.Find("PNL_Option").GetComponent<OptionSC>();
        inforPnl = GameObject.Find("PNL_infor").GetComponent<InfoSC>();
        pausePnl = GameObject.Find("PNL_Pause").GetComponent<PauseSC>();
        gameoverPnl = GameObject.Find("PNL_GameOver").GetComponent<GameOverSC>();
        dataControl = GameObject.Find("OBJ_DataCtr").GetComponent<DataSC>();
        sfxToPlay = GameObject.Find("OBJ_SoundSFX").GetComponent<SoundMN>();


        if (optionPnl != null) optionPnl.gameObject.SetActive(false);
        if (inforPnl != null) inforPnl.gameObject.SetActive(false);
        if (pausePnl != null) pausePnl.gameObject.SetActive(false);
        if (gameoverPnl != null) gameoverPnl.gameObject.SetActive(false);
    }

    #region Check if Player First Play or not
    private void OnCheckPlay()
    {
        if (hasPlayed == 0)
        {
            //Case of first play, set this field to 1 mean not first play any more
            PlayerPrefs.SetInt("HasPlayed", 1);
            SetNewPlayer();
        }
        else if (hasPlayed == 1) LoadOldPlayer(); //Case of not First Play
    }
    private void SetNewPlayer() => dataControl.SetNewPlayer();
    public void LoadOldPlayer() => dataControl.LoadOldPlayer();
    #endregion

    #region Handle UIs revealations
    public void OnShowOption() => optionPnl.gameObject.SetActive(true);
    public void OnShowInforPanel() => inforPnl.gameObject.SetActive(true);
    public void OnShowPause(bool show) => pausePnl.gameObject.SetActive(show);
    public void OnShowGameOver() => gameoverPnl.gameObject.SetActive(true);
    #endregion

    #region Go to Social Medias
    public void ToFB() => Application.OpenURL("https://www.facebook.com/sadeksoftVn");
    public void ToPlayStore() => Application.OpenURL("https://play.google.com/store/apps/developer?id=Sadek+Games+Studio");
    public void ToX() => Application.OpenURL("https://x.com/SadekGame15769");
    public void ToTiktok() => Application.OpenURL("https://www.tiktok.com/@sadekgamestudio23");
    public void ToYTB() => Application.OpenURL("https://www.youtube.com/@SadekGamesStudio");
    public void ToWebsite() => Application.OpenURL("https://sadekgame.wordpress.com/");
    #endregion

    #region Control PlaySound
    public void PlaySlash()
    {
        sfxToPlay.OnSwordSlash();
    }
    public void PlayShootSound()
    {
        sfxToPlay.OnDefaultShoot();
    }
    public void PlayDeadSound()
    {
        sfxToPlay.OnDead();
    }
    public void PlayGatling()
    {
        sfxToPlay.OnPlayGatling();
    }
    public void PlayMissle()
    {
        sfxToPlay.OnPlayMissle();
    }
    public void PlayMissleExploid()
    {
        sfxToPlay.OnPlayMissleExploid();
    }
    public void PlayAbzalat()
    {
        sfxToPlay.OnAbzalatShoot();
    }
    public void PlayFlame()
    {
        sfxToPlay.OnFlame();
    }
    public void PlayRocketPod()
    {
        sfxToPlay.OnRocketRelease();
    }
    #endregion
}
