using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSC : MonoBehaviour
{
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] DataSC data;
    [HideInInspector] AdsMN adsMN;
    [SerializeField] Text gemTxt, coinTxtl;
    public List<GameObject> panels = new List<GameObject>();
    public WarningPanelSC warningPnl;
    private int cointToShow, gemToShow;
    private void Start()
    {
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        data = GameObject.Find("OBJ_DataCtr").GetComponent<DataSC>();
        adsMN = GameObject.Find("AdsMN").GetComponent<AdsMN>();
        warningPnl = GameObject.Find("PNL_WarningPnl").GetComponent<WarningPanelSC>();
        LoadUserInRuntime();
        ClearAllPanels();
    }
    private void OnSetUI()
    {
        gemTxt.text = gemToShow.ToString()+"C";
        coinTxtl.text = cointToShow.ToString()+"D";
    }

    private void ClearAllPanels()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            if(panels[i].activeSelf) panels[i].gameObject.SetActive(false);
        }
        warningPnl.gameObject.SetActive(false);
    }
    public void LoadUserInRuntime()
    {
        //Call everytime in-game need to load data
        gemToShow = data.playerGems;
        cointToShow = data.playerCoin;
        OnSetUI();
    }
    #region Switch Scene & Panels
    public void OnToArena() => genCtr.OnChangeScene(1);
    public void OnToStorymode() =>  genCtr.OnChangeScene(2);
    public void OnToPvP() => genCtr.OnChangeScene(3);
    public void OnToMOBA() => genCtr.OnChangeScene(4);
    public void OnExit() => genCtr.OnChangeScene(5);
    public void OnToOption() => genCtr.OnShowOption();
    public void OnUserInfor() => genCtr.OnShowInforPanel();
    public void OnShowWarningPanel(int callOrder, int contentOrder)
    {
        warningPnl.gameObject.SetActive(true);
        warningPnl.ShowContent(callOrder, contentOrder);
    }
    public void OnShowPanels()
    {
        ClearAllPanels();
    }
    #endregion

    #region Panel Define
    
    #endregion
}
