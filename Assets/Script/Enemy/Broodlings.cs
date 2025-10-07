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
        player = GameObject.Find("Player(Clone)").GetComponent<PlayerSC>();
        StartCoroutine(selfDestruct());
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
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "PAmmo" || collision.gameObject.tag == "PMelee")
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(moveSpd * 1.5f);
        Destroy(gameObject);
        StartCoroutine(selfDestruct());
    }
}
