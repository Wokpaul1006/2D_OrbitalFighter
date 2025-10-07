using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChornowormSC : MonoBehaviour
{
    //Chrono across the screen, each time arrive, lauch a thorn to player direction, thorn not chase player
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] ArcadeGameplaySC arcadeCtr;
    [HideInInspector] GameplayController storyCtr;
    [SerializeField] ThornSC thorne;
    [HideInInspector] PlayerSC player;

    //Unit Prperties
    private float moveSpd;
    private float atkDmg;
    private float atkSpd;
    private float aoedmg; //When dead
    private int hp;
    private int selfScore;
    private float nextX, nextY;
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
        FireToPlayer();
        StartCoroutine(WaitForChrono());
        StartCoroutine(CountToDead());
    }
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
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
        atkSpd = 2;
        aoedmg = 0;
        hp = 2;
        selfScore = 2;

        nextX = nextY = 0;
    }
    void Exploid()
    {
        //Do animation exploid
        Destroy(gameObject);
    }
    void CaculatinNewTarget()
    {
        nextX = Random.Range(-3, 3);
        nextY = Random.Range(-3, 3);
        transform.position = new Vector3(nextY, nextY, 0);
    }
    void FireToPlayer()
    {
        Instantiate(thorne, gameObject.transform.position, Quaternion.identity);
    }
    IEnumerator CountToDead()
    {
        yield return new WaitForSeconds(20);
        Destroy(gameObject);
        StartCoroutine(CountToDead());
    }
    IEnumerator WaitForChrono()
    {
        yield return new WaitForSeconds(moveSpd);
        CaculatinNewTarget();
        FireToPlayer();
        StartCoroutine(WaitForChrono());
    }
}
