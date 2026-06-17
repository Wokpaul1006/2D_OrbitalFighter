using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BroodpinosSC : MonoBehaviour
{
    //Move around player, release broodlings, broodling chase plaver
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] GameplayController arcadeCtr;
    [SerializeField] Broodlings broddLings;
    [HideInInspector] PlayerSC player;

    //Unit Prperties
    private float moveSpd;
    private float atkDmg;
    private float atkSpd;
    private float aoedmg;
    private float curHP, maxHP;
    private int selfScore;
    void Start()
    {
        SetUnitStat();
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        switch (genCtr.gameMode)
        {
            case 1:
                arcadeCtr = GameObject.Find("ArcadeMN").GetComponent<GameplayController>();
                break;
            case 2:
                break;
        }
        player = GameObject.Find("Player(Clone)").GetComponent<PlayerSC>();
        StartCoroutine(ReleaseBroodlings());
        StartCoroutine(CountToDead());
    }
    void Update()
    {
        //MoveLinear();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player") Exploid();
        else if (collision.gameObject.tag == "PAmmo" || collision.gameObject.tag == "PMelee")
        {
            if (curHP <= 0)
            {
                //arcadeCtr.IncreaseScore(selfScore);
                //arcadeCtr.UpdadeEnemyKill();
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
        curHP = 5;
        maxHP = curHP;
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
    IEnumerator ReleaseBroodlings()
    {
        yield return new WaitForSeconds(atkSpd);
        Instantiate(broddLings, transform.position, Quaternion.identity);
        Instantiate(broddLings, transform.position, Quaternion.identity);
        StartCoroutine(ReleaseBroodlings());
    }
}
