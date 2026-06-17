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
        }
    }
    public void OveridePlayerInfo()
    { 
        curHighScore.text = data.pHighscore.ToString();
        totalScore.text = data.pCoin.ToString();
        totoGems.text = data.pGems.ToString();
    }

    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        data.SetNewPlayer();
        OveridePlayerInfo();
    }
    public void SendDatatoServer()
    {
        Debug.Log("On Send Data");
    }
}
