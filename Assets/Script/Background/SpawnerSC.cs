using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSC : MonoBehaviour
{
    //enemies
    [SerializeField] BloatipinozSC bloats;
    [SerializeField] WyvernozSC wyvern;
    [SerializeField] ArachilingsSC arachiling;
    [SerializeField] BroodpinosSC broodpinos;
    [SerializeField] BahamozSC bahamoz;
    [SerializeField] ChornowormSC chronoworm;
    [SerializeField] MaciliozSC macilios;
    [SerializeField] MopivernSC morpivern;
    [SerializeField] TharnatosSC thanatos;
//Controlers
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] ArcadeGameplaySC arcadeCtr;
    [HideInInspector] GameplayController storyCtr;
    public int gameMode;
    public int curLvl;
    private float spawnSpd; //Ajudt this
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
                break;
        }
    }
    #region Arcade Spawn Handler
    public void UpdateCurrentLevelArcade(int i)
    {
        curLvl = i;
        StartCoroutine(SpawnEnemiesArcade(i));
    }
    public IEnumerator SpawnEnemiesArcade(int enemiesOder)
    {
        yield return new WaitForSeconds(3);
        if(enemiesOder < 10)
        {
            switch (enemiesOder)
            {
                case 1:
                    BloatsSpawn();
                    break;
                case 2:
                    WyvernosSpawn();
                    BloatsSpawn();
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
                    BroodpinosSpawn();
                    TharnatosSpawn();
                    break;
                case 6:
                    ChronoWormSpawn();
                    BroodpinosSpawn();
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
                    BloatsSpawn();
                    MorpivernSpawn();
                    BroodpinosSpawn();
                    BahamozSpawn();
                    break;
                case 10:
                    BloatsSpawn();
                    BroodpinosSpawn();
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
        }else if( enemiesOder >= 20)
        {
            //Random enemy to spawn
            //5 spawner on screen work independent
            //Significant increase spawn speed
        }

        StartCoroutine(SpawnEnemiesArcade(enemiesOder));
    }
    #endregion

    #region Object to spawn
    private void BloatsSpawn()
    {
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(bloats, new Vector3(randomX, 3, 0), Quaternion.identity);
        //Invoke("SpawnKamikaze", 0.5f);
    }
    private void WyvernosSpawn()
    {
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(wyvern, new Vector3(randomX, 3, 0), Quaternion.identity);
        //Invoke("SpawnPerShot", 1.25f);
    }
    private void ArachilingSpawn()
    {
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(arachiling, new Vector3(randomX, 3, 0), Quaternion.Euler(0, 0, -90f));
        //Invoke("SpawnDualShot", 1.5f);
    }
    private void BroodpinosSpawn()
    {
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(broodpinos, new Vector3(randomX, 3, 0), Quaternion.Euler(0, 0, -90f));
        //Invoke("SpawnConeShot", 1.75f);
    }
    private void BahamozSpawn()
    {
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(bahamoz, new Vector3(randomX, 3,0), Quaternion.Euler(0, 0, 0f)) ;
        //Invoke("SpawnDiagonal", 1f);
    }
    private void ChronoWormSpawn()
    {
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(chronoworm, new Vector3(randomX, 3, 0), Quaternion.Euler(0, 0, 0f));
        //Invoke("SpawnRandom", 2.25f);
    }
    private void MaciliousSpawn()
    {
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(macilios, new Vector3(randomX, 3, 0), Quaternion.Euler(0, 0, 0f));
        //Invoke("SpawnChrono", 2.5f);
    }
    private void MorpivernSpawn()
    {
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(morpivern, new Vector3(randomX, 3, 0), Quaternion.Euler(0, 0, 0f));
        //Invoke("SpawnChrono", 2.5f);
    }
    private void TharnatosSpawn()
    {
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(thanatos, new Vector3(randomX, 3, 0), Quaternion.Euler(0, 0, 0f));
        //Invoke("SpawnChrono", 2.5f);
    }
    #endregion
}
