using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSC : MonoBehaviour
{
    [SerializeField] OmniMN genCtr;
    [HideInInspector] DataSC dataCtr;
    [HideInInspector] LevelPlaySC storyCtr;
    [HideInInspector] GameplayController arcadeCtr;
    void Start()
    {
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        dataCtr = GameObject.Find("OBJ_DataCtr").GetComponent<DataSC>();
    }
    void Update()
    { }
    public void OnMainMenu()
    {
        //Inter Ads Sometime
        genCtr.OnChangeScene(1);
    }
    public void OnContinue()
    {
        print("Game mode = " + genCtr.gameMode);
        //Load Reward Ads here
        if(genCtr.gameMode == 1)
        {
            //Arcade
            genCtr.OnChangeScene(2);
        }
        else if(genCtr.gameMode == 2)
        {
            //LevelPlay
            genCtr.OnChangeScene(3);
        }
    }
    public void OnContinueByAds()
    {

    }
}
