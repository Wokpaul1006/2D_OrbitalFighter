using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    //Player bullet
    [SerializeField] GameplayController storyCtr;
    [HideInInspector] ArcadeGameplaySC arcadeCtr;
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] PlayerSC player;
    private float movespeed = 8f;
    private int gameMode;
    private float dmg;
    private void Start()
    {
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        gameMode = genCtr.gameMode;
        switch (gameMode)
        {
            case 1:
                arcadeCtr = GameObject.Find("OBJ_ArcadeModeMN").GetComponent<ArcadeGameplaySC>();
                break;
            case 2:
                storyCtr = GameObject.Find("GameplayController").GetComponent<GameplayController>();
                break;
        }
        player = GameObject.Find("Player(Clone)").GetComponent<PlayerSC>();
        StartCoroutine(SelfDestruct());
    }
    private void Update() => MoveLinear();
    private void MoveLinear() => transform.position += Vector3.up * Time.deltaTime * movespeed;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies" || collision.gameObject.tag == "EAmmo") OnHitTarget();
    }
    internal void OnHitTarget()
    {
        player.PlusAP();
        Destroy(gameObject);
    }
    internal IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
        StartCoroutine(SelfDestruct());
    }
}
