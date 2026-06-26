using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSC : MonoBehaviour
{
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] MainMenuSC menuCtr;
    [HideInInspector] DataSC data;
    [HideInInspector] DialougeSC stringText;

    [SerializeField] Button buyGatlingBtn, buyMissleBtn, buyDroneBtn, buyAbzalatBtn, buyRocketPodBnt, buyCelestialSwordBtn, buyFlamethrowlerBtn, buySheildBtn;
    [SerializeField] Text coinText, gemText;
    [SerializeField] Text priceGatlingTxt, priceDroneTxt, priceMissleTxt, priceAbzalatTxt, priceFlamethrowlerTxt, priceRocketPodTxt, priceSwordTxt, priceShieldTxt;
    [SerializeField] Text inforGatlingTxt, inforDroneTxt, inforMissleTxt, inforAbzalatTxt, inforFlameThrowlerTxt, inforRocketPodTxt, inforSwordtxt, inforShieldTxt;
    private int prefCoins, prefGem, prefSlotA, prefSlotB;
    private int priceGatling, priceDrone, priceMissle, priceAbzalat, priceFlame, priceRocketPod, priceSword, priceShield;
    private int indexGetling, indexDrone, indexMissle, indexAbzalat, indexFlame, indexRocketPod, indexSword, indexShile;
    private void Awake()
    {
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        menuCtr = GameObject.Find("HomeMN").GetComponent<MainMenuSC>();
        data = GameObject.Find("OBJ_DataCtr").GetComponent<DataSC>();
        stringText = GameObject.Find("OBJ_Dialgoue").GetComponent<DialougeSC>();
    }
    private void Start()
    {
        GetPlayerData();
    }
    private void OnEnable()
    {
        GetPlayerData();
    }
    void GetPlayerData()
    {
        prefCoins = data.pCoin;
        prefGem = data.pGems;

        UpdateShopUIs(); //Init call
    }
    void UpdateShopUIs()
    {
        //Call each time have chang

        SetCurrency();
    }
  

    #region buy items
    private bool CheckBuy(int pCoin, int itemPrice)
    {
        if (pCoin > itemPrice)
        {
            int temp = pCoin - itemPrice;
            if (temp >= 0)
            {
                return true;
            }
            else return false;
        }else
        {
            return false;
        }
    }
    private void HandleNotAllowBuy(int nameOrder, int contentOrder) 
    {
        //menuCtr.OnShowWarningPanel(nameOrder, contentOrder);
    }
    #endregion

    #region SetItem
    private void SetCurrency()
    {
        prefCoins = data.pCoin;
        prefGem = data.pGems;
        coinText.text = prefCoins.ToString();
        gemText.text = prefGem.ToString();
    }
    #endregion
}
