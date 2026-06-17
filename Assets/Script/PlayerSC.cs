using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerSC : MonoBehaviour
{
    [SerializeField] List<GameObject> playerType = new List<GameObject>();
    [SerializeField] PBullet bullet;
    [HideInInspector] DataSC data;
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] GameplayController gameplayCtr;
    [HideInInspector] LevelPlaySC levelPlayCtr;
    [HideInInspector] List<Vector3> playrPosTransform = new List<Vector3>();
    Vector2 startTouchPos;

    #region clarify player stat
    public int baseHP = 100;
    public float fireRate = 3f; // seconds between calls
    private float timer = 0f;
    private int curPos = 2;
    private int playerWeaponType;
    private int pLifes;
    #endregion
    void Start()
    {
        SettingStartGame();
        GetPlayerStatforStart();
        AssistPlayerFireRate();
        Invoke(nameof(AssistPlayerPos), 1f); //Waith 1 second then assit player pos datas
        InvokeRepeating(nameof(OnAutomaticFire), 0f, fireRate);
    }
    #region Player Init
    private void SettingStartGame()
    {
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        data = GameObject.Find("OBJ_DataCtr").GetComponent<DataSC>();
        switch (genCtr.gameMode)
        {
            case 1:
                gameplayCtr = GameObject.Find("ArcadeMN").GetComponent<GameplayController>();
                break;
            case 2:
                levelPlayCtr = GameObject.Find("LevePlayMN").GetComponent<LevelPlaySC>();
                break;
        }
    }
    private void GetPlayerStatforStart()
    {

    }
   
    private void AssistPlayerPos()
    {
        for(int i = 0; i < gameplayCtr.playerPos.Count; i++)
        {
            playrPosTransform.Add(gameplayCtr.playerPos[i]);
        }
    }
    private void AssistPlayerFireRate()
    {
        switch (playerWeaponType)
        {
            case 0:
                //Pistol
                fireRate = 4f;
                break;
            case 2:
                fireRate = 4f;
                //KimberDual
                break;
            case 3:
                fireRate = 2f;
                //SMG
                break;
            case 4:
                //Rifle
                fireRate = 3f;
                break;
        }
    }
    void Update()
    {
        if(gameplayCtr.isPause == false)
        {
            if (genCtr.platformType == 1)
            {
                //Mobile case
                if (!IsPointerOverUI())
                {
                    OnMoveByTouch();
                }
            }
            else if (genCtr.platformType == 2)
            {
                //Keyboard control
                OnMoveByKey();
            }
        }
    }
    #endregion
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies" || collision.gameObject.tag == "EAmmo")
        {
            //Case of player direct hit enemy
            OnTakeDamage();
        }
    }

    #region Player Activities
    public void OnTakeDamage()
    {
        pLifes--;
        if (pLifes <= 0)
        {
            if (genCtr.gameMode == 1) gameplayCtr.OnOutOfHP();
            else if (genCtr.gameMode == 2) { }
        }
    }
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
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Stationary || t.phase == TouchPhase.Moved)
            {
                float screenMid = Screen.width / 2;
                if (t.position.x > screenMid)
                {
                    curPos--;
                    if (curPos < 0)
                    {
                        curPos = 0;
                    }
                    transform.DOMove(playrPosTransform[curPos], 0.5f);
                }
                else if (t.position.x < screenMid)
                {
                    curPos++;
                    if (curPos > 4)
                    {
                        curPos = 4;
                    }
                    transform.DOMove(playrPosTransform[curPos], 0.5f);
                }
            }
        }
    }
    private void OnMoveByKey()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            curPos--;
            if (curPos < 0)
            {
                curPos = 0;
            }
            transform.DOMove(playrPosTransform[curPos], 0.5f);
        }else if (Input.GetKeyDown(KeyCode.D))
        {

            curPos++;
            if (curPos > 4)
            {
                curPos = 4;
            }
            transform.DOMove(playrPosTransform[curPos], 0.5f);
        }
    }

    private void OnAutomaticFire()
    {
        if(gameplayCtr.isPause == false)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
    #endregion
    //public void OnTakeDamage(int dmg)
    //{
    //    if(hpCur >= dmg)
    //    {
    //        int hpRemain = hpCur - dmg;
    //        hpCur = hpRemain;
    //    }
    //}
}
