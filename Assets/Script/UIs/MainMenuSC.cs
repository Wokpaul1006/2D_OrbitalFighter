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
    private int cointToShow, gemToShow;
    private void Start()
    {
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        data = GameObject.Find("OBJ_DataCtr").GetComponent<DataSC>();
        //LoadUserInRuntime();
        ClearAllPanels();
    }
    public void OnSetUI()
    {
        gemTxt.text = gemToShow.ToString()+"C";
        coinTxtl.text = cointToShow.ToString()+"D";
        curLevel.text = "xxx";
    }

    private void ClearAllPanels()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            if(panels[i].activeSelf) panels[i].gameObject.SetActive(false);
        }
    }
    public void LoadUserInRuntime()
    {
        //Call everytime in-game need to load data
        gemToShow = data.pGems;
        cointToShow = data.pCoin;
        OnSetUI();
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
