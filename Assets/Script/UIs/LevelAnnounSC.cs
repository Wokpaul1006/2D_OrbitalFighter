using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelAnnounSC : MonoBehaviour
{
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] ArcadeGameplaySC arcadeCtr;
    [HideInInspector] GameplayController storyCtr;
    [SerializeField] Text levelTxt, objectivetxt;
    int curLv, gameMode;
    string curObjective;
    void Start()
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
    public void OnShowObjective(int lv, string obj)
    {
        //Call each time up level
        gameObject.SetActive(true);
        curLv = lv;
        curObjective = obj;
        levelTxt.text = curLv.ToString();
        objectivetxt.text = curObjective;
        StartCoroutine(CountToHide());
    }
    private IEnumerator CountToHide()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
