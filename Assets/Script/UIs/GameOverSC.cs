using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSC : MonoBehaviour
{
    [SerializeField] OmniMN genCtr;
    [HideInInspector] DataSC dataCtr;
    [HideInInspector] ArcadeGameplaySC arcadeCtr;
    [HideInInspector] GameplayController storyCtr;
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
        genCtr.OnChangeScene(0);
    }
    public void OnQuitGame() 
    {
        Application.Quit();
    }
    public void OnContinue()
    {
        //Load Reward Ads here
        genCtr.OnChangeScene(1);
    }
}
