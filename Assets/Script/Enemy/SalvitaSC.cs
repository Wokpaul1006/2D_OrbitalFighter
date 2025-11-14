using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalvitaSC : EBullet
{
    [HideInInspector] PlayerSC player;
    void Start()
    {
        moveSpd = 5;
        damage = 6;
        player = GameObject.Find("Player(Clone)").GetComponent<PlayerSC>();
        StartCoroutine(selfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        OnMoveDown(moveSpd);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
