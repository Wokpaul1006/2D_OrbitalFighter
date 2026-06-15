using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    [Header("Objects")]
    [HideInInspector] OmniMN genCtr;
    [SerializeField] PlayerSC player;
    [SerializeField] SpawnerSC spawn;
    [SerializeField] Text lvlTxt, pointTxt;

    [Header("Variables")]
    public int gLevel;
    public int enemiesKilled;
    public bool isPause;

    void Start()
    {
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        SpawnPlayer();
    }

    private void SpawnPlayer() => player = Instantiate(player, Vector3.zero, Quaternion.identity);
   }
