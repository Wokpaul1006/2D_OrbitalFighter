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
        PlayerPrefs.SetInt("Totalscore", 0); //Actual player in-game currency
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

        curDmgMax = PlayerPrefs.GetInt("CurUpgradeDmg");
        curHealthMax = PlayerPrefs.GetInt("CurUpgradeHP");
        curAmmoMax = PlayerPrefs.GetInt("CurUpgradeMgz");
        curHPRegent = PlayerPrefs.GetInt("CurUpgradeRegen");
        curAPCharge = PlayerPrefs.GetInt("CurAPChargeLv");
        curAmmoLoadSpd = PlayerPrefs.GetInt("CurUpgradeReloadLv");
        curAmor = PlayerPrefs.GetInt("CurArmorLevel");

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
}
