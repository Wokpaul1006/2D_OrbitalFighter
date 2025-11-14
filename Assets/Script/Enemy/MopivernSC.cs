using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopivernSC : MonoBehaviour
{
    //Move Linear top down, release savita repeatly
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] ArcadeGameplaySC arcadeCtr;
    [HideInInspector] GameplayController storyCtr;
    [SerializeField] EBullet thorn;
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
        StartCoroutine(ReleaseThorn());
        StartCoroutine(CountToDead());
    }
    void Update()
    {
        MoveLinear();
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
        atkDmg = 6f;
        atkSpd = 1;
        aoedmg = 0;
        hp = 3;
        selfScore = 3;
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
    IEnumerator ReleaseThorn()
    {
        yield return new WaitForSeconds(atkSpd);
        Instantiate(thorn, new Vector3 (transform.position.x +0.5f, transform.position.y, 0), Quaternion.identity);
        Instantiate(thorn, new Vector3(transform.position.x - 0.5f, transform.position.y, 0), Quaternion.identity);
        StartCoroutine(ReleaseThorn());
    }
    private void MoveLinear() => transform.position += Vector3.down * Time.deltaTime * moveSpd;
}
