using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArcadeGameplaySC : MonoBehaviour
{
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] DataSC data;
    [HideInInspector] SpawnerSC spawnerCtr;
    [HideInInspector] LevelAnnounSC levelPanelCtr;
    [SerializeField] PlayerSC player;
    [SerializeField] Button pauseBtn;
    [SerializeField] List<GameObject> heartList = new List<GameObject>();
    [SerializeField] List<GameObject> additionalWeapon = new List<GameObject>();
    [SerializeField] List<GameObject> abilityOder = new List<GameObject>();

    [SerializeField] Text curScoreTxt, curLvTxt, curTimeSurvive, curPosTxt;
    [SerializeField] Text curHPTxt, curAmmoTxt, curAPTxt;
    [SerializeField] Text debugTxt;
    [SerializeField] Image curHPImg, curAmmoImg, curApImg;

    //Variable Declair
    public int arcadeLv, arcadeScore, arcadeTimeSurvive, arcadeLife, arcadeHP, arcadeAP, arcadeAmmo; //Arcade Attribute
    private int pDmg, pHPMax, pHPCur, pAmor, pRegent, pReload, pAmmoMax; //Data load attribute
    private int pWeaponA, pWeaponB, pAbility;
    private int targetLv;
    public Vector3 curPos;
    void Start()
    {
        SettingStart();
        player = Instantiate(player, Vector3.zero, Quaternion.identity);
        CollectPlayerStat();
        GenerateGameplay();
    }
    private void Update()
    {
        curPos = player.transform.position;
    }
    #region Setting Init
    private void SettingStart()
    {
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        data = GameObject.Find("OBJ_DataCtr").GetComponent<DataSC>();
        spawnerCtr = GameObject.Find("OBJ_SpawnerMN").GetComponent<SpawnerSC>();
        levelPanelCtr = GameObject.Find("PNL_LevelAnnouce").GetComponent<LevelAnnounSC>();
        pauseBtn.onClick.AddListener(OnShowPause);
    }
    private void CollectPlayerStat()
    {
        //pDmg = data.curDmgMax;
        //pHPMax = data.curHealthMax;
        //pHPCur = data.curHPRegent;
        //pAmor = data.curAmor;
        //pAmmoMax = data.curAmmoMax;
        //pReload = data.curAmmoLoadSpd;

        //pWeaponA = data.curWeaponSelected_SlotA;
        //pWeaponB = data.curWeaponSelected_SlotB;

        arcadeScore = 0;
        arcadeLv = 0;
        arcadeAP = 0;
        arcadeHP = data.curHealthMax * player.baseHP;
        arcadeAmmo = data.curAmmoMax * player.baseAmmo;

        pWeaponA = data.curWeaponSelected_SlotA;
        pWeaponB = data.curWeaponSelected_SlotB;
        pAbility = data.curAbilitySelected;

        OnInstiatieWeapon_SlotA(pWeaponA);
        OnInstiatieWeapon_SlotB(pWeaponB);
    }
    public void UpdatePlayerStat(int hp, int ap, int ammo, int score, int lv)
    {
        arcadeHP = hp;
        arcadeAP = ap;
        arcadeAmmo = ammo;
        arcadeScore = score;
        arcadeLv = lv;

        UpdateUIs();
    }
    private void GenerateGameplay()
    { 
        arcadeLv = 1;
        arcadeScore = 0;
        arcadeLife = 3;
        arcadeScore = arcadeTimeSurvive = 0;
        DetermineLevel();
    }
    public void UpdateUIs()
    {
        //Call every time have any change on screen
        //Top Panel

        curLvTxt.text = arcadeLv.ToString(); ;
        curScoreTxt.text = arcadeScore.ToString();
        curTimeSurvive.text = arcadeTimeSurvive.ToString();
        curPosTxt.text = player.transform.position.ToString();

        //Bot panel
        curAPTxt.text = arcadeAP.ToString();
        curHPTxt.text = arcadeHP.ToString();
        curAmmoTxt.text = arcadeAmmo.ToString();
    }
    private void OnShowPause() 
    {
        int tempCoin = data.playerCoin + arcadeScore;
        data.UpdatePlayerStatToPlayerPrefs(tempCoin);
        genCtr.OnShowPause(true);
    } 
    #endregion

    #region Gamplay Handlers
    private void DetermineLevel()
    {
        //Call each time meet target score codition
        //Generate next objective
        //Decide which happen in next level
        if(arcadeLv == 1)
        {
            targetLv = 10;
        }else if(arcadeLv > 1 && arcadeScore == targetLv)
        {
            targetLv = arcadeLv * 10;
        }
        levelPanelCtr.OnShowObjective(arcadeLv, targetLv.ToString());
        spawnerCtr.UpdateCurrentLevelArcade(arcadeLv);
    }
    public void DecreaseAmmo()
    {
        arcadeAmmo = player.ammoCur;
        if (arcadeAmmo == data.curAmmoMax * player.baseAmmo) curAmmoImg.fillAmount = 1;
        else if (arcadeAmmo == 0) curAmmoImg.fillAmount = 0;
        else if (arcadeAmmo > 0 && arcadeAmmo < data.curAmmoMax * player.baseAmmo) curAmmoImg.fillAmount = arcadeAmmo / (data.curAmmoMax * player.baseAmmo * 1f);
        UpdatePlayerStat(arcadeHP, arcadeAP, arcadeAmmo, arcadeScore, arcadeLv); //update ammo
    }
    public void IncreaseAP(int ap)
    {
        arcadeAP = ap;
        if (arcadeAP == 100) curApImg.fillAmount = 1;
        else if (arcadeAP == 0) curApImg.fillAmount = 0;
        else if (arcadeAP > 0 && arcadeAP < 100) curApImg.fillAmount = arcadeAP * 0.01f;
        UpdatePlayerStat(arcadeHP, arcadeAP, arcadeAmmo, arcadeScore, arcadeLv); //update AP
    }
    public void DecreaseHP(int hp)
    {
        arcadeHP = hp;
        if (arcadeHP == data.curHealthMax * player.baseHP) curHPImg.fillAmount = 1;
        else if (arcadeHP == 0) curHPImg.fillAmount = 0;
        else if (arcadeHP > 0 && arcadeHP < data.curHealthMax * player.baseHP) curHPImg.fillAmount = arcadeHP / (data.curHealthMax * player.baseHP * 1f);
        UpdatePlayerStat(arcadeHP, arcadeAP, arcadeAmmo, arcadeScore, arcadeLv); //Update HP
    }
    public void IncreaseScore(int score) 
    {
        int tempScore = arcadeScore + score;
        arcadeScore = tempScore;
        if (arcadeScore == targetLv)
        {
            arcadeLv++;
            DetermineLevel();
        }
        UpdatePlayerStat(arcadeHP, arcadeAP, arcadeAmmo, arcadeScore, arcadeLv); //Update score
    }
    private void RegentHP() => player.CallReloadHealth();
    public void OnOutOfHP()
    {
        if (arcadeLife > 0)
        {
            arcadeLife--;
            heartList[arcadeLife].gameObject.SetActive(false);
            RegentHP();
        }
        else if (arcadeLife <= 0)
        {
            genCtr.PlayDeadSound();
            OnOutOfLife();
        }
    }
    private void OnOutOfLife()
    {
        genCtr.OnShowGameOver();
        int tempCoin = data.playerCoin + arcadeScore;
        data.UpdatePlayerStatToPlayerPrefs(tempCoin);
    }
    #endregion
    private void OnInstiatieWeapon_SlotA(int index)
    {
        //Left side
        switch (index)
        {
            case 0: //None
                break;
            case 1: //Cannon
                Instantiate(additionalWeapon[0], new Vector3(player.transform.position.x - 1f, player.transform.position.y, player.transform.position.z),Quaternion.identity, player.transform);
                break;
            case 2: //Drone
                Instantiate(additionalWeapon[2], new Vector3(player.transform.position.x - 1f, player.transform.position.y, player.transform.position.z), Quaternion.identity, player.transform);
                break;
            case 3: //Missle
                Instantiate(additionalWeapon[3], new Vector3(player.transform.position.x - 1f, player.transform.position.y, player.transform.position.z), Quaternion.identity, player.transform);
                break;
            case 4: //Abzalat
                Instantiate(additionalWeapon[4], new Vector3(player.transform.position.x - 1f, player.transform.position.y, player.transform.position.z), Quaternion.identity, player.transform);
                break;
            case 5: //Flame
                Instantiate(additionalWeapon[6], new Vector3(player.transform.position.x - 1f, player.transform.position.y, player.transform.position.z), Quaternion.identity, player.transform);
                break;
            case 6: //Rocket Pod
                Instantiate(additionalWeapon[8], new Vector3(player.transform.position.x - 1f, player.transform.position.y, player.transform.position.z), Quaternion.identity, player.transform);
                break;
            case 7: //Sword
                Instantiate(additionalWeapon[10], new Vector3(player.transform.position.x - 1f, player.transform.position.y, player.transform.position.z), Quaternion.identity, player.transform);
                break;
            case 8: //Cannon
                Instantiate(additionalWeapon[11], new Vector3(player.transform.position.x - 1f, player.transform.position.y, player.transform.position.z), Quaternion.identity, player.transform);
                break;
        }
    }
    private void OnInstiatieWeapon_SlotB(int index)
    {
        //Right side
        switch (index)
        {
            case 0: //None
                break;
            case 1: //Cannon
                Instantiate(additionalWeapon[1], new Vector3(player.transform.position.x + 1f, player.transform.position.y, player.transform.position.z), Quaternion.identity, player.transform);
                break;
            case 2: //Drone
                Instantiate(additionalWeapon[2], new Vector3(player.transform.position.x + 1f, player.transform.position.y, player.transform.position.z), Quaternion.identity, player.transform);
                break;
            case 3: //Missle
                Instantiate(additionalWeapon[3], new Vector3(player.transform.position.x + 1f, player.transform.position.y, player.transform.position.z), Quaternion.identity, player.transform);
                break;
            case 4: //Abzalat
                Instantiate(additionalWeapon[5], new Vector3(player.transform.position.x + 1f, player.transform.position.y, player.transform.position.z), Quaternion.identity, player.transform);
                break;
            case 5: //Flame
                Instantiate(additionalWeapon[7], new Vector3(player.transform.position.x + 1f, player.transform.position.y, player.transform.position.z), Quaternion.identity, player.transform);
                break;
            case 6: //Rocket Pod
                Instantiate(additionalWeapon[9], new Vector3(player.transform.position.x + 1f, player.transform.position.y, player.transform.position.z), Quaternion.identity, player.transform);
                break;
            case 7: //Sword
                Instantiate(additionalWeapon[10], new Vector3(player.transform.position.x + 1f, player.transform.position.y, player.transform.position.z), Quaternion.identity, player.transform);
                break;
            case 8: //Cannon
                Instantiate(additionalWeapon[11], new Vector3(player.transform.position.x + 1f, player.transform.position.y, player.transform.position.z), Quaternion.identity, player.transform);
                break;
        }
    }
    public void PrintDebug(string value) => debugTxt.text = value;
}
