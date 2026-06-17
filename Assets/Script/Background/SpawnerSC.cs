using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSC : MonoBehaviour
{
    //enemies
    [SerializeField] WyvernozSC wyvern;
    [SerializeField] BahamozSC bahamoz;
    [SerializeField] ChornowormSC chronoworm;
    [SerializeField] MaciliozSC macilios;
    [SerializeField] MopivernSC morpivern;
    [SerializeField] TharnatosSC thanatos;
//Controlers
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] GameplayController gameplayCtr;
    [HideInInspector] LevelPlaySC levelPlayCtr;
    public int gameMode;
    public int curLvl;
    private float spawnSpd; //Ajudt this
    Vector3 curSpawnerPos;
    private void Start()
    {
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        gameMode = genCtr.gameMode;
        curSpawnerPos = gameObject.transform.position;
        switch (gameMode)
        {
            case 1:
                gameplayCtr = GameObject.Find("ArcadeMN").GetComponent<GameplayController>();
                break;
            case 2:
                levelPlayCtr = GameObject.Find("LevePlayMN").GetComponent<LevelPlaySC>();
                break;
        }
        InvokeRepeating(nameof(SpawnEnemiesArcade), 0, 5f);
    }
    #region Arcade Spawn Handler
    public void UpdateCurrentLevelArcade(int i)
    {
        curLvl = i;
    }
    public void SpawnEnemiesArcade()
    {
        if(gameplayCtr.isPause == false)
        {
            int enemiesOder;
            enemiesOder = Random.Range(0, 21);
            if (enemiesOder < 10)
            {
                switch (enemiesOder)
                {
                    case 1:
                        break;
                    case 2:
                        WyvernosSpawn();
                        break;
                    case 3:
                        MorpivernSpawn();
                        WyvernosSpawn();
                        break;
                    case 4:
                        TharnatosSpawn();
                        MorpivernSpawn();
                        break;
                    case 5:
                        TharnatosSpawn();
                        break;
                    case 6:
                        ChronoWormSpawn();
                        break;
                    case 7:
                        BahamozSpawn();
                        ChronoWormSpawn();
                        break;
                    case 8:
                        MaciliousSpawn();
                        BahamozSpawn();
                        break;
                    case 9:
                        MorpivernSpawn();
                        BahamozSpawn();
                        break;
                    case 10:
                        ChronoWormSpawn();
                        MaciliousSpawn();
                        BahamozSpawn();
                        break;
                }
            }
            else if (enemiesOder > 10 && enemiesOder < 20)
            {
                //Random enemy to spawn
                //Increase spawn speed
                //3 spawner on screen
            }
            else if (enemiesOder >= 20)
            {
                //Random enemy to spawn
                //5 spawner on screen work independent
                //Significant increase spawn speed
            }
        }
    }
    #endregion

    #region Object to spawn
    private void WyvernosSpawn()
    {
        Instantiate(wyvern,curSpawnerPos, Quaternion.identity);
        //Invoke("SpawnPerShot", 1.25f);
    }
    private void BahamozSpawn()
    {
        Instantiate(bahamoz, curSpawnerPos, Quaternion.Euler(0, 0, 0f)) ;
        //Invoke("SpawnDiagonal", 1f);
    }
    private void ChronoWormSpawn()
    {
        Instantiate(chronoworm, curSpawnerPos, Quaternion.Euler(0, 0, 0f));
        //Invoke("SpawnRandom", 2.25f);
    }
    private void MaciliousSpawn()
    {
        Instantiate(macilios, curSpawnerPos, Quaternion.Euler(0, 0, 0f));
        //Invoke("SpawnChrono", 2.5f);
    }
    private void MorpivernSpawn()
    {
        Instantiate(morpivern, curSpawnerPos, Quaternion.Euler(0, 0, 0f));
        //Invoke("SpawnChrono", 2.5f);
    }
    private void TharnatosSpawn()
    {
        Instantiate(thanatos, curSpawnerPos, Quaternion.Euler(0, 0, 0f));
        //Invoke("SpawnChrono", 2.5f);
    }
    #endregion
}
