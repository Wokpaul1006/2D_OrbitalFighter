using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSC : MonoBehaviour
{
    [HideInInspector] OptionSC option;

    [HideInInspector] public string nameFistPlay;
    [HideInInspector] public string playerName;
    [HideInInspector] public int pHighscore, pLevelPlay;
    [HideInInspector] public int pCoin, pGems; //Economic
    [HideInInspector] private int curThemeState, curSFXState;
    [HideInInspector] private int playerClass;

    public bool isFirstPlay;
    public int pAllowClaimDaily, pDailyStreak;
    public string pLastDailyClaim;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        //PlayerPrefs.DeleteAll();
        option = GameObject.Find("PNL_Option").GetComponent<OptionSC>();
        SettingStart();
    }
    private void Start()
    {    }
    private void Update()
    {    }
    private void SettingStart()
    {
        if (CheckFirstPlay() == true)
        {
            SetNewPlayer();
        }
        else if (CheckFirstPlay() == false)
        {
            LoadOldPlayer();
        }
        ///infor = GameObject.Find("GenMN").GetComponent<PlayerInforSC>();
    }

    public void SetNewPlayer()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            nameFistPlay = "Player";
        }
        else if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            nameFistPlay = "Player" + (Random.Range(100000, 30000)).ToString();
        }

        //Player information
        Debug.Log("in new layer");
        PlayerPrefs.SetInt("HasPlayed", 0);
        PlayerPrefs.SetInt("Highscore", 0); //For total overview, leaderboard
        PlayerPrefs.SetInt("LevelPlayed", 0); //Player Level
        PlayerPrefs.SetInt("Totalscore", 0); //Actual player in-game currency
        PlayerPrefs.SetInt("TotalGems", 0); //Player's PIA currency

        //Upgrade able section
        PlayerPrefs.SetInt("Class", 0);

        //System Control
        PlayerPrefs.SetInt("SFXState", 1);
        PlayerPrefs.SetInt("ThemeState", 1);

        //Patrol Reward
        PlayerPrefs.SetInt("AllowClaimDaily", 0);
        PlayerPrefs.SetString("LastPatrolDailyTime", "");
        PlayerPrefs.SetInt("PatrolDailyStreak", 0);

        Invoke("LoadOldPlayer", 3f); //De tam thoi
    }
    public void LoadOldPlayer()
    {
        //This function load player information if there are not FIRST PLAY
        playerName = PlayerPrefs.GetString("PlayerName");
        pHighscore = PlayerPrefs.GetInt("Highscore");
        pLevelPlay = PlayerPrefs.GetInt("LevelPlayed");
        pCoin = PlayerPrefs.GetInt("Totalscore");
        pGems = PlayerPrefs.GetInt("TotalGems");
        playerClass = PlayerPrefs.GetInt("Class");

        //Patrol Reward
        pLastDailyClaim = PlayerPrefs.GetString("LastPatrolDailyTime");
        pAllowClaimDaily = PlayerPrefs.GetInt("AllowClaimDaily");
        pDailyStreak = PlayerPrefs.GetInt("PatrolDailyStreak");

        CheckSoundState();
    }
    public void CheckSoundState()
    {
        curThemeState = PlayerPrefs.GetInt("ThemeState");
        curSFXState = PlayerPrefs.GetInt("SFXState");

        option.sfxState = curSFXState;
        option.themeState = curThemeState;
    }
    public void UpdateSoundState(int sfx, int theme)
    {
        curThemeState = theme;
        curSFXState = sfx;
        PlayerPrefs.SetInt("SFXState", curSFXState);
        PlayerPrefs.SetInt("ThemeState", curThemeState);
    }
    public void UpdatePlayerEconomics(int state, int coin, int gems)
    {
        switch (state)
        {
            case 0:
                PlayerPrefs.SetInt("Totalscore", pCoin);
                pCoin = PlayerPrefs.GetInt("Totalscore");
                break;
            case 1:
                PlayerPrefs.SetInt("TotalGems", pGems);
                pGems = PlayerPrefs.GetInt("TotalGems");
                break;
        }
    }
    public void UpdateHighScore(int value)
    {
        PlayerPrefs.SetInt("Highscore", value); //For total overview, leaderboard
        pHighscore = PlayerPrefs.GetInt("Highscore");
    }
    public void UpdateLevelPlay(int value)
    {
        PlayerPrefs.SetInt("LevelPlayed", value); //Player Level
        pLevelPlay = PlayerPrefs.GetInt("LevelPlayed");
    }
    public void DeletePlayer() { PlayerPrefs.DeleteAll(); }

    #region Data Update
    public void UpdateFirsrtPlay()
    {
        PlayerPrefs.SetInt("HasPlayed", 1);
    }
    public void UpdatePName(string name)
    {
        PlayerPrefs.SetString("PlayerName", name);
        playerName = PlayerPrefs.GetString("PlayerName");
    }
    public void UpdateSFXState(int sfxState)
    {
        PlayerPrefs.SetInt("sfxState", sfxState);
        curSFXState = PlayerPrefs.GetInt("sfxState");
    }
    public void UpdateThemeState(int thameState)
    {
        PlayerPrefs.SetInt("soundState", thameState);
        curThemeState = PlayerPrefs.GetInt("soundState");
    }
    public void UpdatePlayerClass(int value)
    {
        PlayerPrefs.SetInt("Class", value);
        playerClass = PlayerPrefs.GetInt("Class");
    }
    public void UpdatePatrolDailyReward(string lastPatrolDaily)
    {
        PlayerPrefs.SetString("LastPatrolDailyTime", lastPatrolDaily);
        pLastDailyClaim = PlayerPrefs.GetString("LastPatrolDailyTime");
    }
    public void UpdateAllowClaimDaily(int state)
    {
        PlayerPrefs.SetInt("AllowClaimDaily", state);
        pAllowClaimDaily = PlayerPrefs.GetInt("AllowClaimAllowClaimDaily");
    }
    public void UpdateStreak(int value)
    {
        PlayerPrefs.SetInt("PatrolDailyStreak", value);
        pDailyStreak = value;
    }
    #endregion
    private bool CheckFirstPlay()
    {
        if (PlayerPrefs.GetInt("HasPlayed") == 0) return isFirstPlay = true;
        else return false;
    }
}
