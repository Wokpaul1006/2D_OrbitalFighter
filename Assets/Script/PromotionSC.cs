using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromotionSC : MonoBehaviour
{
    public void OnToGames(int index)
    {
        switch (index)
        {
            case 0:
                Application.OpenURL("https://play.google.com/store/apps/details?id=com.SDSoft.Arcade_Dino_Adventure_2D&pcampaignid=web_share");
                break;
            case 1:
                Application.OpenURL("https://play.google.com/store/apps/details?id=com.SDSoft.Arcade_UtopiaRise_2D&pcampaignid=web_share");
                break;
            case 2:
                Application.OpenURL("https://play.google.com/store/apps/details?id=com.SDSoft.MegrePlanet&pcampaignid=web_share");
                break;
            case 3:
                Application.OpenURL("https://play.google.com/store/apps/details?id=com.SDSoft.Petopia&pcampaignid=web_share");
                break;
            case 4: Application.OpenURL("https://play.google.com/store/apps/details?id=com.SDSoft.MergeGrocery&pcampaignid=web_share");
                break;
            case 5:
                Application.OpenURL("https://play.google.com/store/apps/developer?id=Sadek+Games+Studio");
                break;
        }
    }
}
