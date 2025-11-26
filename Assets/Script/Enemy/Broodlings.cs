using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broodlings : EBullet
{
    [HideInInspector] PlayerSC player;
    void Start()
    {
        moveSpd = 3f;
        damage = 10;
        base.Start();
        player = GameObject.Find("Player(Clone)").GetComponent<PlayerSC>();
    }
    private void Update()
    {
        OnMoveToPlayer(moveSpd);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.OnTakeDamage(damage);
            arcadeCtr.UpdadeEnemyKill();
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "PAmmo" || collision.gameObject.tag == "PMelee")
        {
            arcadeCtr.UpdadeEnemyKill();
            Destroy(gameObject);
        }
    }
}
