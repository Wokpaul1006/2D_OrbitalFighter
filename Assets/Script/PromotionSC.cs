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
                //Dino
                Application.OpenURL("https://play.google.com/store/apps/details?id=com.SDSoft.Arcade_Dino_Adventure_2D&pcampaignid=web_share");
                break;
            case 1:
                //Utopia
                Application.OpenURL("https://play.google.com/store/apps/details?id=com.SDSoft.Arcade_UtopiaRise_2D&pcampaignid=web_share");
                break;
            case 2:
                //Merge Planet
                Application.OpenURL("https://play.google.com/store/apps/details?id=com.SDSoft.MegrePlanet&pcampaignid=web_share");
                break;
            case 3:
                //Petopia
                Application.OpenURL("https://play.google.com/store/apps/details?id=com.SDSoft.Petopia&pcampaignid=web_share");
                break;
            case 4: 
                //Merge Grocery
                Application.OpenURL("https://play.google.com/store/apps/details?id=com.SDSoft.MergeGrocery&pcampaignid=web_share");
                break;
            case 5:
                //Castle Defender
                Application.OpenURL("https://play.google.com/store/apps/details?id=com.SDSoft.AgeOfCkauz&pcampaignid=web_share");
                break;
            case 6:
                //Idle Shooter
                Application.OpenURL("https://play.google.com/store/apps/details?id=com.SDSoft.OrbitalFighter&pcampaignid=web_share");
                break;
            case 7:
                //Weapon Smith
                Application.OpenURL("https://play.google.com/store/apps/details?id=com.SDSoft.TerraInAction&pcampaignid=web_share");
                break;
            case 8:
                //Alien Merge
                Application.OpenURL("https://play.google.com/store/apps/details?id=com.SDSoft.MorpinosEvolution&pcampaignid=web_share");
                break;
            case 9:
                //Animal Merge
                Application.OpenURL("https://play.google.com/store/apps/developer?id=Sadek+Games+Studio");
                break;
            case 10:
                //Gravity Tower
                Application.OpenURL("https://play.google.com/store/apps/developer?id=Sadek+Games+Studio");
                break;
            case 11:
                //Fish Tank
                Application.OpenURL("https://play.google.com/store/apps/developer?id=Sadek+Games+Studio");
                break;
            case 12:
                //Topdown Fishshooter
                Application.OpenURL("https://play.google.com/store/apps/developer?id=Sadek+Games+Studio");
                break;
            case 13:
                //Grocery Store
                Application.OpenURL("https://play.google.com/store/apps/developer?id=Sadek+Games+Studio");
                break;
            case 14:
                //Cocktail Mixer
                Application.OpenURL("https://play.google.com/store/apps/developer?id=Sadek+Games+Studio");
                break;
            case 15:
                //Grocery Waiters
                Application.OpenURL("https://play.google.com/store/apps/developer?id=Sadek+Games+Studio");
                break;
        }
    }
}
