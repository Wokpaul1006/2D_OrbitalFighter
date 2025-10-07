using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoSC : Singleton<InfoSC>
{
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] DataSC data;
    [SerializeField] Text playerName, curHighScore, totalScore, totoGems;
    [SerializeField] Text curDmglvl, curAmmoCapacity, curHPLvl, curRegentLvl, curReloadLvl, curAmorLv;

    string pName;
    int pHighscore, pMoneyIngame;
    float pCurDmg, pHPLv, pRegentLv, pReloadSpd;
    void Start()
    {
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        data = GameObject.Find("OBJ_DataCtr").GetComponent<DataSC>();
    }
    private void Update()
    {
        if (gameObject.activeSelf)
        {
            playerName.text = data.playerName;
            OveridePlayerInfo();
            OveridePlayerStat();
        }
    }
    public void OveridePlayerInfo()
    { 
        curHighScore.text = data.playerHighscore.ToString();
        totalScore.text = data.playerCoin.ToString();
        totoGems.text = data.playerGems.ToString();
    }

    public void OveridePlayerStat()
    {
        curDmglvl.text = data.curDmgMax.ToString();
        curHPLvl.text = data.curHealthMax.ToString();
        curAmmoCapacity.text = data.curAmmoMax.ToString();
        curRegentLvl.text = data.curHPRegent.ToString();
        curReloadLvl.text = data.curAmmoLoadSpd.ToString();
        curAmorLv.text = data.curAmor.ToString();
    }
    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        data.SetNewPlayer();
        OveridePlayerInfo();
        OveridePlayerStat();
    }
    public void SendDatatoServer()
    {
        Debug.Log("On Send Data");
    }
}
