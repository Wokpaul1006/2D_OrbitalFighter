using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    [Header("Objects")]
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] DataSC data;
    [SerializeField] List<Transform> defPos = new List<Transform>();
    [SerializeField] PlayerSC player;
    [SerializeField] List<SpawnerSC> spawn = new List<SpawnerSC>();
    [SerializeField] Text lvlTxt, pointTxt;

    [HideInInspector] public List<Vector3> playerPos = new List<Vector3>();

    [Header("Variables")]
    public int gLevel;
    public int enemiesKilled;
    public bool isPause;
    private int arcadeLife = 3;
    public int arcadeLv, arcadeScore, targetLv;
    void Start()
    {
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        data = GameObject.Find("OBJ_DataCtr").GetComponent<DataSC>();
        SetupPlayerPos();
        SpawnPlayer();
        isPause = true;
        Invoke(nameof(EnablePlayGame), 5f);
    }

    private void SpawnPlayer() => player = Instantiate(player, playerPos[2], Quaternion.identity);
    private void SetupPlayerPos()
    {
        playerPos.Add(new Vector3(-2, -3, 0));
        playerPos.Add(new Vector3(-1, -3, 0));
        playerPos.Add(new Vector3(0, -3, 0));
        playerPos.Add(new Vector3(1, -3, 0));
        playerPos.Add(new Vector3(2, -3, 0));
    }
    private void EnablePlayGame()
    {
        isPause = false;
    }
    public void OnOutOfHP()
    {
        if (arcadeLife > 0)
        {
            arcadeLife--;
            //heartList[arcadeLife].gameObject.SetActive(false);
        }
        else if (arcadeLife <= 0)
        {
            genCtr.PlayDeadSound();
            OnOutOfLife();
        }
    }
    private void OnOutOfLife()
    {
        genCtr.OnShowGameOver();
        int tempCoin = data.pCoin + arcadeScore;
        data.UpdatePlayerEconomics(1, tempCoin, 0);
    }
    public void IncreaseScore(int score)
    {
        int tempScore = arcadeScore + score;
        arcadeScore = tempScore;
        if (arcadeScore == targetLv)
        {
            arcadeLv++;
            DetermineLevel();
        }
        //UpdatePlayerStat(arcadeHP, arcadeAP, arcadeAmmo, arcadeScore, arcadeLv); //Update score
    }
    private void DetermineLevel()
    {
        //Call each time meet target score codition
        //Generate next objective
        //Decide which happen in next level
        if (arcadeLv == 1)
        {
            targetLv = 10;
        }
        else if (arcadeLv > 1 && arcadeScore == targetLv)
        {
            targetLv = arcadeLv * 10;
        }
        //spawnerCtr.UpdateCurrentLevelArcade(arcadeLv);
    }
    public void OnBuyDefPoint()
    {

    }
}
