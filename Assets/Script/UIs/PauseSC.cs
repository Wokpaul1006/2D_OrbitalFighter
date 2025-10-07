using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSC : Singleton<PauseSC>
{
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] GameplayController gameplayCtr;
    [HideInInspector] DataSC datCtr;
    // Start is called before the first frame update
    void Start()
    {
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        datCtr = GameObject.Find("OBJ_DataCtr").GetComponent<DataSC>();
    }
    public void OnResume()
    {
        genCtr.OnShowPause(false);
    }
    public void OnMainMenu()
    {
        //Inter Ads Sometime
        genCtr.OnChangeScene(0);
        genCtr.OnShowPause(false);
    }
}
