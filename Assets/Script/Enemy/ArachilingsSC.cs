using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArachilingsSC : MonoBehaviour
{
    //Move Linear top down, back turn of off screen, shot 3 thorn at once to player direction, thorn not chase player
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
        //StartCoroutine(RelaseSavita());
        StartCoroutine(CountToDead());
    }
    void Update()
    {
        MoveLinear();
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
    private void MoveLinear() => transform.position += Vector3.down * Time.deltaTime * moveSpd;
    private IEnumerator RelaseSavita()
    {
        yield return new WaitForSeconds(atkSpd);
        Instantiate(savita, new Vector3(transform.position.x + 0.5f, transform.position.y, 0), Quaternion.identity);
        Instantiate(savita, transform.position, Quaternion.identity);
        Instantiate(savita, new Vector3(transform.position.x - 0.5f, transform.position.y, 0), Quaternion.identity);
        StartCoroutine(RelaseSavita());
    }
}
