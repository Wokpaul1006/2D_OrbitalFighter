using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialSwordSC : SecondaryWeapSC
{
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] PlayerSC player;
    public float speed = 50f;
    //Ratate Around Player
    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(player.transform.position, new Vector3(0,0,0.1f), speed * Time.deltaTime);
    }

    void OnInit()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemies" || collision.gameObject.tag == "EAmmo")
        {
            genCtr.PlaySlash();
            Destroy(collision.gameObject);
        }
    }
}
