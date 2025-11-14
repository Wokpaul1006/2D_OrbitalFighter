using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TharnatosSC : MonoBehaviour
{
    //Move random axis, release surrounded thorns
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] ArcadeGameplaySC arcadeCtr;
    [HideInInspector] GameplayController storyCtr;
    [SerializeField] SalvitaSC savita;
    [HideInInspector] PlayerSC player;

    //Unit Prperties
    private float moveSpd;
    private float atkDmg;
    private float atkSpd;
    private float aoedmg;
    private int hp;
    private int selfScore;
    private int randAxis; //0 = Horizontal Left, 1 = horizontal right, 2 = vertical down, 3 = vertical up
    void Start()
    {
        SetUnitStat();
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        switch (genCtr.gameMode)
        {
            case 1:
                arcadeCtr = GameObject.Find("OBJ_ArcadeModeMN").GetComponent<ArcadeGameplaySC>();
                break;
            case 2:
                break;
        }
        player = GameObject.Find("Player(Clone)").GetComponent<PlayerSC>();
        randAxis = Random.Range(0, 3);
        StartCoroutine(RelaseSavita());
        StartCoroutine(CountToDead());
    }
    void Update()
    {
        switch (randAxis)
        {
            case 0:
                MoveLeft();
                break;
            case 1:
                MOveRight();
                break;
            case 2:
                MoveDown();
                break;
            case 3:
                MoveUp();
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player") Exploid();
        else if (collision.gameObject.tag == "PAmmo" || collision.gameObject.tag == "PMelee")
        {
            int tempDmgTake;
            tempDmgTake = hp - player.dmgCur;
            hp = tempDmgTake;
            if (hp <= 0)
            {
                arcadeCtr.IncreaseScore(selfScore);
                Exploid();
            }
        }
    }
    void SetUnitStat()
    {
        moveSpd = 1.5f;
        atkDmg = 1;
        atkSpd = 0.5f;
        aoedmg = 0;
        hp = 2;
        selfScore = 2;
    }
    void Exploid()
    {
        //Do animation exploid
        Destroy(gameObject);
    }
    IEnumerator CountToDead()
    {
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
        StartCoroutine(CountToDead());
    }
    IEnumerator RelaseSavita()
    {
        yield return new WaitForSeconds(atkSpd);
        Instantiate(savita, transform.position, Quaternion.identity);
        StartCoroutine(RelaseSavita());
    }
    #region movement
    void MoveUp() => gameObject.transform.position = Vector3.up * moveSpd * Time.deltaTime;
    void MoveDown() => gameObject.transform.position = Vector3.down * moveSpd * Time.deltaTime;
    void MOveRight() => gameObject.transform.position = Vector3.right * moveSpd * Time.deltaTime;
    void MoveLeft() => gameObject.transform.position = Vector3.left * moveSpd * Time.deltaTime;
    #endregion
}
