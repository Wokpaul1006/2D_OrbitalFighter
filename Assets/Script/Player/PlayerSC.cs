using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerSC : MonoBehaviour
{
    [SerializeField] SuperBulletSC sBullet;
    [SerializeField] PBullet bullet;
    [HideInInspector] DataSC data;
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] ArcadeGameplaySC arcadeCtr;
    [HideInInspector] GameplayController stroyCtr;

    #region clarify player stat
    public float moveSpd;
    public bool isReload;
    public int dmgCur, hpCur, ammoCur, apCur, amorCur;
    public float ammoLoadSpdCur, apLoadSpdCur, hpRegnetSpdCur;
    public int curWeaponA, curWeaponB;
    public int baseAmmo = 30;
    public int baseHP = 100;
    private Vector3 MousePos;
    #endregion
    void Start()
    {
        SettingStartGame();
        switch (genCtr.gameMode)
        {
            case 1:
                arcadeCtr = GameObject.Find("OBJ_ArcadeModeMN").GetComponent<ArcadeGameplaySC>();
                break;
            case 2:
                break;
        }
        GetPlayerStatforStart();
    }
    void Update()
    {
        if (genCtr.platformType == 1)
        {
            //Mobile case
            if (!IsPointerOverUI())
            {
                OnMoveByTouch();
                OnFireNormalByTouch();
            }
        }
        else if (genCtr.platformType == 2)
        {
            //Keyboard control
            OnMoveByKey();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFireNormalByKey();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies" || collision.gameObject.tag == "EAmmo")
        {
            //Case of player direct hit enemy
            OnTakeDamage(10);
            if (apCur <= 100) { PlusAP(); }
            if (hpCur <= 0)
            {
                if (genCtr.gameMode == 1) arcadeCtr.OnOutOfHP();
                else if (genCtr.gameMode == 2) { }
            }
            else
            {
                if (genCtr.gameMode == 1) arcadeCtr.IncreaseScore(1);
                else if (genCtr.gameMode == 2)
                {
                    //call Score Handle of Story mode
                }
            }

        }
        else if (collision.gameObject.tag == "Meteor") arcadeCtr.OnOutOfHP();
    }
    #region Player Init
    private void GetPlayerStatforStart()
    {
        apCur = 0;
        apLoadSpdCur = (float)data.curAPCharge;
        dmgCur = data.curDmgMax;
        hpCur = data.curHealthMax * baseHP;
        ammoCur = data.curAmmoMax * baseAmmo;
        curWeaponA = data.curWeaponSelected_SlotA;
        curWeaponB = data.curWeaponSelected_SlotB;

        SetReload();
        SetRegentHp();
        SetAmour();
        //SetSecondary();

        //Update more code of additional weapon here
        if (genCtr.gameMode == 1) 
        {
            arcadeCtr.UpdatePlayerStat(hpCur, apCur, ammoCur, arcadeCtr.arcadeScore, arcadeCtr.arcadeLv); //UPdate start
        }else if (genCtr.gameMode == 2) 
        { 

        }
    }
    private void SettingStartGame()
    {
        MousePos = transform.position;
        isReload = false;

        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        data = GameObject.Find("OBJ_DataCtr").GetComponent<DataSC>();
    }
    private void SetReload()
    {
        float tempAmmoLoadSpd = (float)data.curAmmoLoadSpd;
        ammoLoadSpdCur = (3 * (1 / tempAmmoLoadSpd));
    }
    private void SetRegentHp() 
    {
        float tempRegnetSpdCur = (float)data.curHPRegent;
        hpRegnetSpdCur = (3 * (1 / tempRegnetSpdCur));
    } 
    private void SetAmour()
    {
        switch (data.curAmor)
        {
            case 1:
                amorCur = 1;
                break;
            case 2:
                amorCur = 2;
                break;
            case 3:
                amorCur = 3;
                break;
            case 4:
                amorCur = 4;
                break;
            case 5:
                amorCur = 5;
                break;
            case 6:
                amorCur = 6;
                break;
            case 7:
                amorCur = 7;
                break;
            case 8:
                amorCur = 8;
                break;
            case 9:
                amorCur = 9;
                break;
            case 10:
                amorCur = 10;
                break;
        }
    }
    #endregion

    #region Player Activities
    private bool IsPointerOverUI()
    {
        //For mobile touches
        if (Input.touchCount > 0)
        {
            return EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
        }

        // For mouse (editor, PC testing)
        return EventSystem.current.IsPointerOverGameObject();
    }
    private void OnMoveByTouch()
    {
        if (Input.touchCount > 0)
        {
            MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Get current position of mouse on screen
            MousePos = new Vector3(MousePos.x, MousePos.y, 0f);
            Vector3 temp = Vector3.Lerp(transform.position, MousePos, 100 * Time.deltaTime);
            transform.position = temp;
        }
    }
    private void OnMoveByKey()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Get current position of mouse on screen
        MousePos = new Vector3(MousePos.x, MousePos.y, 0f);
        Vector3 temp = Vector3.Lerp(transform.position, MousePos, 100 * Time.deltaTime);
        transform.position = temp;
    }
    private void OnFireNormalByTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary)
            {
                if (isReload == false)
                {
                    InvokeRepeating(nameof(OnFire), 0f, 1f);
                    genCtr.PlayDefault();
                    if (ammoCur <= 0)
                    {
                        isReload = true;
                        arcadeCtr.DecreaseAmmo();
                        StartCoroutine(ReloadAmmo());
                    }
                    else if (ammoCur >= data.curAmmoMax)
                    {
                        arcadeCtr.DecreaseAmmo();
                        StopCoroutine(ReloadAmmo());
                    }
                }
            }
        }
    }

    private void OnFire()
    {
        Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 1f), Quaternion.identity);
        ammoCur--;
    }
    private void OnFireNormalByKey()
    {
        if (isReload == false)
        {
            Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 1f), Quaternion.identity);
            ammoCur -= 1;
            if (ammoCur <= 0)
            {
                isReload = true;
                arcadeCtr.DecreaseAmmo();
                StartCoroutine(ReloadAmmo());
            }
            else if (ammoCur >= data.curAmmoMax)
            {
                arcadeCtr.DecreaseAmmo();
                StopCoroutine(ReloadAmmo());
            }
        }
    }
    private void OnReleaseAbility()
    {
        //Button call
        if(apCur >= 100)
        {
            //Do ability
        }
    }
    public IEnumerator ReloadAmmo()
    {
        yield return new WaitForSeconds((float)(ammoLoadSpdCur));
        ammoCur = data.curAmmoMax * baseAmmo;
        isReload = false;
        //Add reload animation here
        arcadeCtr.DecreaseAmmo();
    }
    public IEnumerator RegentHealth()
    {
        yield return new WaitForSeconds((float)hpRegnetSpdCur);
        if (hpCur >= 0 && hpCur < data.curHealthMax * 100)
        {
            hpCur = data.curHealthMax * baseHP;
            arcadeCtr.arcadeHP = hpCur;
            StartCoroutine(RegentHealth());
        }
        else if (hpCur >= data.curHealthMax * 100)
        {
            StopCoroutine(RegentHealth());
        }
    }
    public void CallReloadHealth() => StartCoroutine(RegentHealth());
    #endregion
    public void OnTakeDamage(int dmg)
    {
        if(hpCur >= dmg)
        {
            int hpRemain = hpCur - dmg;
            hpCur = hpRemain;
            arcadeCtr.DecreaseHP(hpCur);
        }
    }
    public void PlusAP()
    {
        apCur += 10;
        arcadeCtr.IncreaseAP(apCur);
    }
}
