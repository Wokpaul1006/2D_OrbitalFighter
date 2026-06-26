using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPlaySC : MonoBehaviour
{
    [SerializeField] List<SpawnerSC> spawnerList = new List<SpawnerSC>();
    [SerializeField] List<GameObject> defendList = new List<GameObject>();
    [SerializeField] Text startgameCountDownTxt;
    [SerializeField] GameObject countdownPnl;

    private int curLevel, startgameCountdown;
    private int pHP; 
    void Start()
    {
        startgameCountdown = 5;
        InvokeRepeating(nameof(CountdownStartGame), 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CountdownStartGame()
    {
        startgameCountdown--;
        startgameCountDownTxt.text = startgameCountdown.ToString();
        if (startgameCountdown <= 0) countdownPnl.SetActive(false);
    }
}
