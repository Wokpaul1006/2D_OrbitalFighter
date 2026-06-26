using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSC : MonoBehaviour
{
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] DataSC data;
    [SerializeField] Text gemTxt, coinTxtl, curLevel;

    public List<GameObject> panels = new List<GameObject>();
    private int cointToShow, gemToShow, levelToShow;
    private void Start()
    {
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        data = GameObject.Find("OBJ_DataCtr").GetComponent<DataSC>();

        ClearAllPanels();
        OnSetUI();
    }
    public void OnSetUI()
    {
        gemToShow = data.pGems;
        cointToShow = data.pCoin;
        levelToShow = data.pLevelPlay;

        print("data.Pcoin = " + data.pCoin);
        print("in set UI, coin = " + cointToShow);

        gemTxt.text = gemToShow.ToString()+"C";
        coinTxtl.text = cointToShow.ToString()+"D";
        curLevel.text = "LEVEL " + levelToShow.ToString();
    }

    private void ClearAllPanels()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            if(panels[i].activeSelf) panels[i].gameObject.SetActive(false);
        }
    }
    #region Switch Scene & Panels
    public void ToArcade()
    {
        print("in call to Arcade");
        genCtr.OnChangeScene(2);
    }
    public void ToLevelPlay()
    {
        genCtr.OnChangeScene(3);
    }
    public void OnToOption() => genCtr.OnShowOption();
    public void OnUserInfor() => genCtr.OnShowInforPanel();
    public void OnShowPanels(int caseIndex)
    {
        if (caseIndex == -1) { ClearAllPanels(); }
        else if (caseIndex != -1) panels[caseIndex].gameObject.SetActive(true);
    }
    #endregion
    
}
