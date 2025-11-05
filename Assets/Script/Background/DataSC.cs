using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSC : MonoBehaviour
{
    [HideInInspector] public string nameFistPlay;
    [HideInInspector] public string playerName;
    [HideInInspector] public int playerHighscore;
    [HideInInspector] public int playerCoin; //TotaScore
    [HideInInspector] public int playerGems;
    [HideInInspector] public int curDmgMax, curHealthMax, curAmmoMax;
    [HideInInspector] public int curHPRegent, curAPCharge, curAmmoLoadSpd, curAmor;
    [HideInInspector] public int curWeaponSelected_SlotA, curWeaponSelected_SlotB;
    [HideInInspector] public int curAbilitySelected;
    [HideInInspector] private int curThemeState, curSFXState;
    [HideInInspector] OptionSC option;

    public int pAllowClaimDaily;
    public int pDailyStreak;
    public string pLastDailyClaim;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        option = GameObject.Find("PNL_Option").GetComponent<OptionSC>();
    }
    private void Start()
    {    }
    private void Update()
    {    }
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
        PlayerPrefs.SetString("PlayerName", nameFistPlay);
        PlayerPrefs.SetInt("Highscore", 0); //For total overview, leaderboard
        PlayerPrefs.SetInt("Totalscore", 1000); //Actual player in-game currency
        PlayerPrefs.SetInt("TotalGems", 0); //Player's PIA currency
        PlayerPrefs.SetInt("CurWeaponSlot_A", 0); //index of weapon order in list. 0 is non
        PlayerPrefs.SetInt("CurWeaponSlot_B", 0); //index of weapon order in list. 0 is non
        PlayerPrefs.SetInt("CurAblility", 0); //index of ability order in list. 0 is non

        //Upgrade able section
        PlayerPrefs.SetInt("CurUpgradeDmg", 1); //Damage upgrade
        PlayerPrefs.SetInt("CurUpgradeHP", 1); //Max HP upgrade
        PlayerPrefs.SetInt("CurUpgradeMgz", 1); //Max Ammo magazine upgrade
        PlayerPrefs.SetInt("CurUpgradeReloadLv", 1); //Upgrade Reload Spd
        PlayerPrefs.SetInt("CurUpgradeRegen", 1); //Upgrade HP regent spd
        PlayerPrefs.SetInt("CurArmorLevel", 1); //Upgrade amor lv
        PlayerPrefs.SetInt("CurAPChargeLv", 1); //Upgrade AP load spd

        //System Control
        PlayerPrefs.SetInt("SFXState", 1);
        PlayerPrefs.SetInt("ThemeState", 1);

        //Patrol Reward
        PlayerPrefs.SetInt("AllowClaimDaily", 0);
        PlayerPrefs.SetInt("AllowClaimMonthly", 0);
        PlayerPrefs.SetString("LastPatrolDailyTime", "");
        PlayerPrefs.SetString("LastPatrolMonthlyTime", "");
        PlayerPrefs.SetInt("PatrolDailyStreak", 0);
        PlayerPrefs.SetInt("PatrolMonthlyStreak", 0);

        Invoke("LoadOldPlayer", 3f); //De tam thoi
    }
    public void GetOldPlayer()
    {
        //This function load player information if there are not FIRST PLAY
        playerName = PlayerPrefs.GetString("PlayerName");
        playerHighscore = PlayerPrefs.GetInt("Highscore");
        playerCoin = PlayerPrefs.GetInt("Totalscore");
        playerGems = PlayerPrefs.GetInt("TotalGems");
        curWeaponSelected_SlotA = PlayerPrefs.GetInt("CurWeaponSlot_A");
        curWeaponSelected_SlotB = PlayerPrefs.GetInt("CurWeaponSlot_B");
        curAbilitySelected = PlayerPrefs.GetInt("CurAblility");

        print("curWeaponSelected_SlotA = " + curWeaponSelected_SlotA);
        print("curWeaponSelected_SlotB = " + curWeaponSelected_SlotB);

        curDmgMax = PlayerPrefs.GetInt("CurUpgradeDmg");
        curHealthMax = PlayerPrefs.GetInt("CurUpgradeHP");
        curAmmoMax = PlayerPrefs.GetInt("CurUpgradeMgz");
        curHPRegent = PlayerPrefs.GetInt("CurUpgradeRegen");
        curAPCharge = PlayerPrefs.GetInt("CurAPChargeLv");
        curAmmoLoadSpd = PlayerPrefs.GetInt("CurUpgradeReloadLv");
        curAmor = PlayerPrefs.GetInt("CurArmorLevel");

        //Patrol Reward
        pLastDailyClaim = PlayerPrefs.GetString("LastPatrolDailyTime");
        //pLastMonthlyClaim = PlayerPrefs.GetString("LastPatrolMonthlyTime");
        pAllowClaimDaily = PlayerPrefs.GetInt("AllowClaimDaily");
        //pAllowClaimMonthly = PlayerPrefs.GetInt("AllowClaimMonthly");
        pDailyStreak = PlayerPrefs.GetInt("PatrolDailyStreak");
        //pMonthlyStreak = PlayerPrefs.GetInt("PatrolMonthlyStreak");

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
    public void UpdatePlayerStatToPlayerPrefs(int coin)
    {
        playerCoin = coin;
        int tempHighScore;
        tempHighScore = playerHighscore + playerCoin;
        playerHighscore = tempHighScore;
        PlayerPrefs.SetInt("Totalscore", playerCoin);
        PlayerPrefs.SetInt("Highscore", playerHighscore);
    }
    public void DeletePlayer() { PlayerPrefs.DeleteAll(); }

    #region Data Update
    public void UpdatePName(string name)
    {
        PlayerPrefs.SetString("PlayerName", name);
        playerName = PlayerPrefs.GetString("PlayerName");
    }
    public void UpdateHighScore(int highScore)
    {
        PlayerPrefs.SetInt("Highscore", highScore);
        playerHighscore = PlayerPrefs.GetInt("Highscore");
    }
    //public void UpdateHighLv(int highLv)
    //{
    //    PlayerPrefs.SetInt("PHighestLevel", highLv);
    //    p = PlayerPrefs.GetInt("PHighestLevel");
    //}
    //public void UpdateStoryLv(int curStoryLv)
    //{
    //    PlayerPrefs.SetInt("CurrentStoryLevel", curStoryLv);
    //    pStoryLvl = PlayerPrefs.GetInt("CurrentStoryLevel");
    //}
    public void UpdateTotalScore(int currency)
    {
        PlayerPrefs.SetInt("Totalscore", currency);
        playerCoin = PlayerPrefs.GetInt("Totalscore");
    }
    public void UpdateTotalGem(int gems)
    {
        PlayerPrefs.SetInt("TotalGems", gems);
        playerGems = PlayerPrefs.GetInt("TotalGems");
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
    public void UpdateAbility(int abilityOder)
    {
        PlayerPrefs.SetInt("CurAblility", abilityOder);
        curAbilitySelected = PlayerPrefs.GetInt("CurAblility");
    }
    public void UpdateWeapon(int weaponOder)
    {
        PlayerPrefs.SetInt("CurWeaponID", weaponOder);
        if(curWeaponSelected_SlotA == 0)
        {
            PlayerPrefs.SetInt("CurWeaponSlot_A", weaponOder);
            curWeaponSelected_SlotA = PlayerPrefs.GetInt("CurWeaponSlot_A");
        }else if(curWeaponSelected_SlotA != 0 && curWeaponSelected_SlotB == 0)
        {
            PlayerPrefs.SetInt("CurWeaponSlot_B", weaponOder);
            curWeaponSelected_SlotB = PlayerPrefs.GetInt("CurWeaponSlot_B");
        }
        else if(curWeaponSelected_SlotA != 0 && curWeaponSelected_SlotB != 0) 
        { }
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
    public void UpdateStreak(int typeStreak, int value)
    {
        switch (typeStreak)
        {
            case 1:
                PlayerPrefs.SetInt("PatrolDailyStreak", value);
                pDailyStreak = value;
                break;
            //case 2:
            //    PlayerPrefs.SetInt("PatrolMonthlyStreak", value);
            //    pMonthlyStreak = value;
            //    break;
        }
    }
    #endregion
}
