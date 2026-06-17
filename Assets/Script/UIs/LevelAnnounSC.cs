using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelAnnounSC : MonoBehaviour
{
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] LevelPlaySC storyCtr;
    [HideInInspector] GameplayController arcadeCtr;
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
                arcadeCtr = GameObject.Find("ArcadeMN").GetComponent<GameplayController>();
                break;
            case 2:
                storyCtr = GameObject.Find("LevePlayMN").GetComponent<LevelPlaySC>();
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
