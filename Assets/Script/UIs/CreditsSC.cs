using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsSC : MonoBehaviour
{
    [HideInInspector] OmniMN genCtr;
    [SerializeField] Button FBBtn, XBtn, YTBBtn, SiteBtn, TiktokBtn, StoreBtn;
    void Start()
    {
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        AssitMethods();
    }
    void AssitMethods()
    {
        FBBtn.onClick.AddListener(ToFB);
        XBtn.onClick.AddListener(ToX);
        YTBBtn.onClick.AddListener(ToYTB);
        SiteBtn.onClick.AddListener(ToSite);
        TiktokBtn.onClick.AddListener(ToTT);
        StoreBtn.onClick.AddListener(ToStore);
    }
    private void ToFB() => genCtr.ToFB();
    private void ToYTB() => genCtr.ToYTB();
    private void ToX() => genCtr.ToX();
    private void ToTT() => genCtr.ToTiktok();
    private void ToStore() => genCtr.ToPlayStore();
    private void ToSite() => genCtr.ToWebsite();
}
