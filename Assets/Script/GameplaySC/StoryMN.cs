using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryMN : MonoBehaviour
{
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] DataSC data;
    [HideInInspector] SpawnerSC spawnerCtr;
    [HideInInspector] DialougeSC logs;
    [SerializeField] PlayerSC player;
    [SerializeField] Button pauseBtn;
    [SerializeField] List<GameObject> heartList = new List<GameObject>();
    [SerializeField] List<GameObject> additionalWeapon = new List<GameObject>();
    [SerializeField] List<GameObject> abilityOder = new List<GameObject>();

    [SerializeField] GameObject BossInforPnl;
    [SerializeField] Text objectiveTxt1, objectiveTxt2, objectiveTxt3, bossName;

    private bool isFighBoss;

    private void Start()
    {
        isFighBoss = false; //Enable if meet all objectives;
    }

    private void OnFighBoss()
    {
        BossInforPnl.gameObject.SetActive(true);
        bossName.text = "";
    }
}
