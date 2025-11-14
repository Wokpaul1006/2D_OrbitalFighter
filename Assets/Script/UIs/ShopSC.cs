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
        menuCtr = GameObject.Find("Main_MN").GetComponent<MainMenuSC>();
        data = GameObject.Find("OBJ_DataCtr").GetComponent<DataSC>();
        stringText = GameObject.Find("OBJ_Dialgoue").GetComponent<DialougeSC>();
    }
    private void Start()
    {
        GetPlayerData();
        SetButtonLisenter();
    }
    private void OnEnable()
    {
        GetPlayerData();
    }
    void GetPlayerData()
    {
        prefCoins = data.playerCoin;
        prefGem = data.playerGems;
        prefSlotA = data.curWeaponSelected_SlotA;
        prefSlotB = data.curWeaponSelected_SlotB;

        UpdateShopUIs(); //Init call
    }
    void UpdatePlayerData(int coin, int weaponOrder)
    {
        //Call each time buy something
        data.UpdateTotalScore(coin);
        data.UpdateWeapon(weaponOrder);
        SetCurrency();
    }
    void UpdateShopUIs()
    {
        //Call each time have chang

        SetCurrency();
        SetGatling();
        SetDrone();
        SetMissle();
        SetAbzalat();
        SetFlame();
        SetRocketPod();
        SetSword();
        SetShield();
    }
    void SetButtonLisenter()
    {
        buyGatlingBtn.onClick.AddListener(OnBuyGatling);
        buyDroneBtn.onClick.AddListener(OnBuyDrone);
        buyMissleBtn.onClick.AddListener(OnBuyMissile);
        buyAbzalatBtn.onClick.AddListener(OnBuyAbzalat);
        buyFlamethrowlerBtn.onClick.AddListener(OnBuyFlameThrowler);
        buyRocketPodBnt.onClick.AddListener(OnBuyRocketPod);
        buyCelestialSwordBtn.onClick.AddListener(OnBuySword);
        buySheildBtn.onClick.AddListener(OnBuyShield);
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
            menuCtr.OnShowWarningPanel(2, 2);
            return false;
        }
    }
    private void HandleNotAllowBuy(int nameOrder, int contentOrder) 
    {
        menuCtr.OnShowWarningPanel(nameOrder, contentOrder);
    } 
    public void OnBuyGatling()
    {
        print("in buy gatling");
        if(CheckBuy(prefCoins, priceGatling) == true)
        {
            if (prefSlotA != 0 && prefSlotB != 0)
            {
                //Not allow to buy
                HandleNotAllowBuy(1,1);
            }else if (prefSlotA == 0 && prefSlotB == 0 || prefSlotA == 0 && prefSlotB != 0)
            {
                //Slot A free || Slot A & B free
                int newCoin = prefCoins - priceGatling;
                UpdatePlayerData(newCoin, indexGetling);
                HandleNotAllowBuy(3, 3);
            }
            else if (prefSlotA != 0 && prefSlotB == 0)
            {
                //Slot B free, Slot A occupied
                int newCoin = prefCoins - priceGatling;
                UpdatePlayerData(newCoin, indexGetling);
                HandleNotAllowBuy(3, 3);
            }
        }
    }
    public void OnBuyDrone()
    {
        print("in buy drone");
        if (CheckBuy(prefCoins, priceDrone) == true)
        {
            if (prefSlotA != 0 && prefSlotB != 0)
            {
                //Not allow to buy
                HandleNotAllowBuy(1,1);
            }
            else if (prefSlotA == 0 && prefSlotB == 0 || prefSlotA == 0 && prefSlotB != 0)
            {
                //Slot A free || Slot A & B free
                int newCoin = prefCoins - priceDrone;
                UpdatePlayerData(newCoin, indexDrone);
                HandleNotAllowBuy(3, 3);
            }
            else if (prefSlotA != 0 && prefSlotB == 0)
            {
                //Slot B free, Slot A occupied
                int newCoin = prefCoins - priceDrone;
                UpdatePlayerData(newCoin, indexDrone);
                HandleNotAllowBuy(3, 3);
            }
        }
    }
    public void OnBuyMissile()
    {
        print("in buy missle");
        if (CheckBuy(prefCoins, priceMissle) == true)
        {
            if (prefSlotA != 0 && prefSlotB != 0)
            {
                //Not allow to buy
                HandleNotAllowBuy(1,1);
            }
            else if (prefSlotA == 0 && prefSlotB == 0 || prefSlotA == 0 && prefSlotB != 0)
            {
                //Slot A free || Slot A & B free
                int newCoin = prefCoins - priceMissle;
                UpdatePlayerData(newCoin, indexMissle);
                HandleNotAllowBuy(3, 3);
            }
            else if (prefSlotA != 0 && prefSlotB == 0)
            {
                //Slot B free, Slot A occupied
                int newCoin = prefCoins - priceMissle;
                UpdatePlayerData(newCoin, indexMissle);
                HandleNotAllowBuy(3, 3);
            }
        }
    }
    public void OnBuyAbzalat()
    {
        print("in buy abzalat");
        if (CheckBuy(prefCoins, priceAbzalat) == true)
        {
            if (prefSlotA != 0 && prefSlotB != 0)
            {
                //Not allow to buy
                HandleNotAllowBuy(1, 1);
            }
            else if (prefSlotA == 0 && prefSlotB == 0 || prefSlotA == 0 && prefSlotB != 0)
            {
                //Slot A free || Slot A & B free
                int newCoin = prefCoins - priceAbzalat;
                UpdatePlayerData(newCoin, indexAbzalat);
                HandleNotAllowBuy(3, 3);
            }
            else if (prefSlotA != 0 && prefSlotB == 0)
            {
                //Slot B free, Slot A occupied
                int newCoin = prefCoins - priceAbzalat;
                UpdatePlayerData(newCoin, indexAbzalat);
                HandleNotAllowBuy(3, 3);
            }
        }
    }
    public void OnBuyFlameThrowler()
    {
        print("in buy flame");
        if (CheckBuy(prefCoins, priceFlame) == true)
        {
            if (prefSlotA != 0 && prefSlotB != 0)
            {
                //Not allow to buy
                HandleNotAllowBuy(1, 1);
            }
            else if (prefSlotA == 0 && prefSlotB == 0 || prefSlotA == 0 && prefSlotB != 0)
            {
                //Slot A free || Slot A & B free
                int newCoin = prefCoins - priceFlame;
                UpdatePlayerData(newCoin, indexFlame);
                HandleNotAllowBuy(3, 3);
            }
            else if (prefSlotA != 0 && prefSlotB == 0)
            {
                //Slot B free, Slot A occupied
                int newCoin = prefCoins - priceFlame;
                UpdatePlayerData(newCoin, indexFlame);
                HandleNotAllowBuy(3, 3);
            }
        }
    }
    public void OnBuyRocketPod()
    {
        if (CheckBuy(prefCoins, priceRocketPod) == true)
        {
            if (prefSlotA != 0 && prefSlotB != 0)
            {
                //Not allow to buy
                HandleNotAllowBuy(1, 1);
            }
            else if (prefSlotA == 0 && prefSlotB == 0 || prefSlotA == 0 && prefSlotB != 0)
            {
                //Slot A free || Slot A & B free
                int newCoin = prefCoins - priceRocketPod;
                UpdatePlayerData(newCoin, indexRocketPod);
                HandleNotAllowBuy(3, 3);
            }
            else if (prefSlotA != 0 && prefSlotB == 0)
            {
                //Slot B free, Slot A occupied
                int newCoin = prefCoins - priceRocketPod;
                UpdatePlayerData(newCoin, indexRocketPod);
                HandleNotAllowBuy(3, 3);
            }
        }
    }
    public void OnBuySword()
    {
        if (CheckBuy(prefCoins, priceSword) == true)
        {
            if (prefSlotA != 0 && prefSlotB != 0)
            {
                //Not allow to buy
                HandleNotAllowBuy(1, 1);
            }
            else if (prefSlotA == 0 && prefSlotB == 0 || prefSlotA == 0 && prefSlotB != 0)
            {
                //Slot A free || Slot A & B free
                int newCoin = prefCoins - priceSword;
                UpdatePlayerData(newCoin, indexRocketPod);
                HandleNotAllowBuy(3, 3);
            }
            else if (prefSlotA != 0 && prefSlotB == 0)
            {
                //Slot B free, Slot A occupied
                int newCoin = prefCoins - priceSword;
                UpdatePlayerData(newCoin, indexRocketPod);
                HandleNotAllowBuy(3, 3);
            }
        }
    }
    public void OnBuyShield()
    {
        if (CheckBuy(prefCoins, priceShield) == true)
        {
            if (prefSlotA != 0 && prefSlotB != 0)
            {
                //Not allow to buy
                HandleNotAllowBuy(1, 1);
            }
            else if (prefSlotA == 0 && prefSlotB == 0 || prefSlotA == 0 && prefSlotB != 0)
            {
                //Slot A free || Slot A & B free
                int newCoin = prefCoins - priceShield;
                UpdatePlayerData(newCoin, indexRocketPod);
                HandleNotAllowBuy(3, 3);
            }
            else if (prefSlotA != 0 && prefSlotB == 0)
            {
                //Slot B free, Slot A occupied
                int newCoin = prefCoins - priceShield;
                UpdatePlayerData(newCoin, indexRocketPod);
                HandleNotAllowBuy(3, 3);
            }
        }
    }
    #endregion

    #region SetItem
    private void SetCurrency()
    {
        prefCoins = data.playerCoin;
        prefGem = data.playerGems;
        coinText.text = prefCoins.ToString();
        gemText.text = prefGem.ToString();
    }
    private void SetGatling()
    {
        indexGetling = 1;
        inforGatlingTxt.text = stringText.inforGatling;
        priceGatling = 100;
        priceGatlingTxt.text = priceGatling.ToString() + "C";
    }
    private void SetDrone()
    {
        indexDrone = 2;
        inforDroneTxt.text = stringText.inforDrone;
        priceDrone = 1000;
        priceDroneTxt.text = priceDrone.ToString() + "C";
    }
    private void SetMissle()
    {
        indexMissle = 3;
        inforMissleTxt.text = stringText.inforMissle;
        priceMissle = 300;
        priceMissleTxt.text = priceMissle.ToString() + "C";
    }
    private void SetAbzalat() 
    {
        indexAbzalat = 4;
        inforAbzalatTxt.text = stringText.inforAbzalat;
        priceAbzalat = 300;
        priceAbzalatTxt.text = priceAbzalat.ToString() + "C";
    }
    private void SetFlame()
    {
        indexFlame = 5;
        inforFlameThrowlerTxt.text = stringText.inforFlame;
        priceFlame = 600;
        priceFlamethrowlerTxt.text = priceFlame.ToString() + "C";
    }
    private void SetRocketPod()
    {
        indexRocketPod = 6;
        inforRocketPodTxt.text = stringText.inforRocketPod;
        priceRocketPod = 900;
        priceRocketPodTxt.text = priceRocketPod.ToString() + "C";
    }
    private void SetSword()
    {
        indexSword = 7;
        inforSwordtxt.text = stringText.inforSword;
        priceSword = 300;
        priceSwordTxt.text = priceSword.ToString() + "C";
    }
    private void SetShield()
    {
        indexShile = 8;
        inforShieldTxt.text = stringText.inforShield;
        priceShield = 300;
        priceShieldTxt.text = priceShield.ToString() + "C";
    }
    #endregion
}
