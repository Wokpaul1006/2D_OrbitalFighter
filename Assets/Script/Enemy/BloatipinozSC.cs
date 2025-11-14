using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloatipinozSC : MonoBehaviour
{
    //Charge to player and boom
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] ArcadeGameplaySC arcadeCtr;
    [HideInInspector] GameplayController storyCtr;
    [HideInInspector] PlayerSC player;
    private Vector3 targetPos;

    //Unit Prperties
    private float moveSpd;
    private float atkDmg;
    private float atkSpd;
    private float aoedmg;
    private int hp;
    private int selfScore;
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
        StartCoroutine(CountToDead());
    }
    void Update()
    {
        UpdatePlayerPos();
        MoveToPlayer();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ON Hit object");
        if (collision.gameObject.tag == "Player") Exploid();
        else if (collision.gameObject.tag == "PAmmo" || collision.gameObject.tag == "PMelee")
        {
            Debug.Log("In collide Ammo");
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
        moveSpd = 0.5f;
        atkDmg = 0;
        atkSpd = 0;
        aoedmg = 10;
        hp = 1;
        selfScore = 1;
    }
    void UpdatePlayerPos() => targetPos = arcadeCtr.curPos;
    void MoveToPlayer() 
    {
        Vector3 direction = (targetPos - transform.position).normalized; // direction to player
        gameObject.transform.position += direction * moveSpd * Time.deltaTime;
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
}
