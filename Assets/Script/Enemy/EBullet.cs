using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : MonoBehaviour
{
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] ArcadeGameplaySC arcadeCtr;
    [HideInInspector] GameplayController storyCtr;
    private Vector3 targetPos;

    internal int damage;
    internal float moveSpd, tempXDiagonal, tempYDiagonal;
    private void Start()
    {
        GetComponent<Rigidbody2D>();
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        switch (genCtr.gameMode)
        {
            case 1:
                arcadeCtr = GameObject.Find("OBJ_ArcadeModeMN").GetComponent<ArcadeGameplaySC>();
                break;
            case 2:
                break;
        }
        StartCoroutine(CountToDead());
    }
    void Update()
    {    }
    internal void OnMoveDown(float spd) => transform.position += Vector3.down * Time.deltaTime * spd;
    internal void OnMoveUp(float spd) => transform.position += Vector3.up * Time.deltaTime * spd;
    internal void OnMoveLeft(float spd) => transform.position += Vector3.left * Time.deltaTime * spd;
    internal void OnMoveRight(float spd) => transform.position += Vector3.right * Time.deltaTime * spd;
    internal void OnMoveDownRight(float spd)
    {
        tempXDiagonal = Time.deltaTime * moveSpd * 0.5f;
        tempYDiagonal = -Time.deltaTime * moveSpd * 0.5f;
        transform.position += new Vector3(tempXDiagonal, tempYDiagonal, 0);
    }
    internal void OnMoveUpRight(float spd)
    {
        tempXDiagonal = Time.deltaTime * moveSpd * 0.5f;
        tempYDiagonal = Time.deltaTime * moveSpd * 0.5f;
        transform.position += new Vector3(tempXDiagonal, tempYDiagonal, 0);
    }
    internal void OnMoveUpLeft(float spd)
    {
        tempXDiagonal = -Time.deltaTime * moveSpd * 0.5f;
        tempYDiagonal = Time.deltaTime * moveSpd * 0.5f;
        transform.position += new Vector3(tempXDiagonal, tempYDiagonal, 0);
    }
    internal void OnMoveDownLeft(float spd)
    {
        tempXDiagonal = -Time.deltaTime * moveSpd * 0.5f;
        tempYDiagonal = -Time.deltaTime * moveSpd * 0.5f;
        transform.position += new Vector3(tempXDiagonal, tempYDiagonal, 0);
    }
    internal void OnMoveToPlayer(float spd)
    {
        targetPos = arcadeCtr.curPos;
        Vector3 direction = (targetPos - transform.position).normalized; // direction to player
        gameObject.transform.position += direction * moveSpd * Time.deltaTime;
    }
    internal IEnumerator CountToDead()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
        StartCoroutine(CountToDead());
    }
}
