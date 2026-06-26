using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySC : MonoBehaviour
{
    [HideInInspector] internal OmniMN genCtr;
    [HideInInspector] internal GameplayController arcadeCtr;
    [SerializeField] internal SalvitaSC thorne;
    [HideInInspector] internal PlayerSC player;

    //Unit Prperties
    internal float moveSpd, curHP;
    internal int selfScore, atkSpd;
    protected virtual void Start()
    {
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
        InvokeRepeating(nameof(RelaseSavita), 0f, atkSpd);
        Invoke(nameof(CountToDead), 15f);
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
            if (curHP <= 0)
            {
                arcadeCtr.IncreaseScore(selfScore);
                Exploid();
            }
        }
    }
    void Exploid()
    {
        //Do animation exploid
        arcadeCtr.IncreaseScore(selfScore);
        Destroy(gameObject);
    }
    void CountToDead()
    {
        Destroy(gameObject);
    }
    void MoveLinear() => transform.position += Vector3.down * Time.deltaTime * moveSpd;
    void RelaseSavita()
    {
        Instantiate(thorne, transform.position, Quaternion.identity);
    }
}
