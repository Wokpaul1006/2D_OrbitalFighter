using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorySC : MonoBehaviour
{
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] DataSC data;

    [SerializeField] Text pMoneyTxt;
    [SerializeField] Text priceDmgTxt, priceHPMaxTxt, priceMgzSzTxt, priceAmorTxt, priceReloadTxt, priceRegentTxt;
    [SerializeField] Text curDmgTxt, curHPTxt, curMgzSizeTxt, curAmorTxt, curReloadSpdTxt, curRegentTxt;

    //Local Variables
    private int priceDmg, priceHPMax, priceMgzSz, priceAmor, priceReloadSpd, priceRegentSpd;
    private int amoryDmg, amoryHPMax, amoryMgzSize, amoryAmorLv, armoryReloadLv, armoryRegentLv;
    private int prefDmg, prefHPMax, prefMgzSize, prefAmor, prefReloadSpd, prefRegentSpd;
    private string priceUnit = "C";
    private int prefCoins;
    private void Awake()
    {
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        data = GameObject.Find("OBJ_DataCtr").GetComponent<DataSC>();
    }
    void Start()
    {
        GetPlayer();
    }
    #region gameplay handle
    void GetPlayer()
    {
        prefDmg = PlayerPrefs.GetInt("CurUpgradeDmg");
        prefHPMax = PlayerPrefs.GetInt("CurUpgradeHP");
        prefMgzSize = PlayerPrefs.GetInt("CurUpgradeMgz");
        prefAmor = PlayerPrefs.GetInt("CurArmorLevel");
        prefRegentSpd = PlayerPrefs.GetInt("CurUpgradeRegen");
        prefReloadSpd = PlayerPrefs.GetInt("CurUpgradeReloadLv");
        prefCoins = PlayerPrefs.GetInt("Totalscore");

        amoryDmg = prefDmg;
        amoryHPMax = prefHPMax;
        amoryAmorLv = prefAmor;
        amoryMgzSize = prefMgzSize;
        armoryReloadLv = prefReloadSpd;
        armoryRegentLv = prefRegentSpd;

        SetPrices();
        UpdateUI_Amory(); //Call Init
    }
    void UpdateUI_Amory()
    {
        pMoneyTxt.text = prefCoins.ToString();
        curDmgTxt.text = amoryDmg.ToString();
        curHPTxt.text = amoryHPMax.ToString();
        curAmorTxt.text = amoryAmorLv.ToString();
        curMgzSizeTxt.text = amoryMgzSize.ToString();
        curRegentTxt.text = armoryRegentLv.ToString();
        curReloadSpdTxt.text = armoryReloadLv.ToString();
    }
    void UpdateData_Amory()
    {
        //Call each time buy something
        PlayerPrefs.SetInt("CurUpgradeDmg", prefDmg);
        PlayerPrefs.SetInt("CurUpgradeHP", prefHPMax);
        PlayerPrefs.SetInt("CurUpgradeMgz", prefMgzSize);
        PlayerPrefs.SetInt("CurArmorLevel", prefAmor);
        PlayerPrefs.SetInt("CurUpgradeRegen", prefRegentSpd);
        PlayerPrefs.SetInt("CurUpgradeReloadLv", prefReloadSpd);
    }
    void UpdateData_Money() => PlayerPrefs.SetInt("CurUpgradeDmg", prefCoins); //Call each time spent money
    #endregion

    #region Upgrade site
    public void OnUpgradeDmg()
    {
        if(prefCoins >= priceDmg)
        {
            int temp = prefCoins - priceDmg;
            prefCoins = temp;
            UpdateData_Money();
            amoryDmg += 1;
            prefDmg = amoryDmg;
            UpdateData_Amory();
            UpdateUI_Amory();
        }else
        {
            Debug.Log("Out of Money");
        }
        SetPrices();
        UpdateUI_Price();
    }
    public void OnUpgradeHPLvl()
    {
        if (prefCoins >= prefHPMax)
        {
            int temp = prefCoins - priceHPMax;
            prefCoins = temp;
            UpdateData_Money();
            amoryHPMax += 1;
            prefHPMax = amoryHPMax;
            UpdateData_Amory();
            UpdateUI_Amory();
        }
        else
        {
            Debug.Log("Out of Money");
        }
        SetPrices();
        UpdateUI_Price();
    }
    public void OnUpgradeMgzSz()
    {
        if (prefCoins >= priceMgzSz)
        {
            int temp = prefCoins - priceMgzSz;
            prefCoins = temp;
            UpdateData_Money();
            amoryMgzSize += 1;
            prefMgzSize = amoryMgzSize;
            UpdateData_Amory();
            UpdateUI_Amory();
        }
        else
        {
            Debug.Log("Out of Money");
        }
        SetPrices();
        UpdateUI_Price();
    }
    public void OnUpgradeAmorLv()
    {
        if (prefCoins >= priceAmor)
        {
            int temp = prefCoins - priceAmor;
            prefCoins = temp;
            UpdateData_Money();
            amoryAmorLv += 1;
            prefAmor = amoryAmorLv;
            UpdateData_Amory();
            UpdateUI_Amory();
        }
        else
        {
            Debug.Log("Out of Money");
        }
        SetPrices();
        UpdateUI_Price();
    }
    public void OnUpgradeRegentLv()
    {
        if (prefCoins >= priceRegentSpd)
        {
            int temp = prefCoins - priceRegentSpd;
            prefCoins = temp;
            UpdateData_Money();
            armoryRegentLv += 1;
            prefRegentSpd = armoryRegentLv;
            UpdateData_Amory();
            UpdateUI_Amory();
        }
        else
        {
            Debug.Log("Out of Money");
        }
        SetPrices();
        UpdateUI_Price();
    }
    public void OnUpgradeReloadLv()
    {
        if (prefCoins >= priceReloadSpd)
        {
            int temp = prefCoins - priceReloadSpd;
            prefCoins = temp;
            UpdateData_Money();
            armoryReloadLv += 1;
            prefReloadSpd = armoryReloadLv;
            UpdateData_Amory();
            UpdateUI_Amory();
        }
        else
        {
            Debug.Log("Out of Money");
        }
        SetPrices();
        UpdateUI_Price();
    }
    #endregion

    #region Prices
    void SetPrices()
    {
        priceDmg = amoryDmg * 10;
        priceHPMax = amoryHPMax * 10;
        priceAmor = amoryAmorLv * 10;
        priceMgzSz = amoryMgzSize * 10;
        priceReloadSpd = armoryReloadLv * 10;
        priceRegentSpd = armoryRegentLv * 10;

        UpdateUI_Price();
    }
    void UpdateUI_Price() 
    {
        priceDmgTxt.text = priceDmg.ToString();
        priceHPMaxTxt.text = priceHPMax.ToString();
        priceAmorTxt.text = priceAmor.ToString();
        priceMgzSzTxt.text = priceMgzSz.ToString();
        priceReloadTxt.text = priceReloadSpd.ToString();
        priceRegentTxt.text = priceRegentSpd.ToString();
    }
    #endregion

    public void OnCloseArmory()
    {

    }
}
