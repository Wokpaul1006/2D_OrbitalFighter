using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PatrolEarningSC : MonoBehaviour
{
    [HideInInspector] DataSC data;
    [HideInInspector] OmniMN genCtr;
    [HideInInspector] MainMenuSC menu;

    [SerializeField] List<Button> rewardBtn = new List<Button>();
 
    private const string LastPatrolTimeKey = "LastPatrolTime";
    private const string PatrolStreakKey = "PatrolStreak";
    private int baseReward = 10; // example reward, x2 for each time count
    public int rewardToGive;
    private bool isAllowDailyClaim;
    private int streakDaily;
    private string lastCollectDay;
    void Start()
    {
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        data = GameObject.Find("OBJ_AdsCtr").GetComponent<DataSC>();
        menu = GameObject.Find("HomeMN").GetComponent<MainMenuSC>();

        isAllowDailyClaim = false;
        streakDaily = data.pDailyStreak;
        lastCollectDay = "";
        rewardToGive = 0;
        ShowRewardDaily();
        OnCheckDailyClaimOnInit();
    }
    public void OnClosePanel() => menu.OnUserInfor();

    #region Handle Claim Daily
    void ShowRewardDaily()
    {
        print(data.pAllowClaimDaily);
        if (data.pLastDailyClaim == "")
        {
            //First day of play
            isAllowDailyClaim = true;
            for (int i = 0; i < rewardBtn.Count; i++)
            {
                rewardBtn[i].GetComponent<Button>().interactable = false;
            }
            rewardBtn[0].GetComponent<Button>().interactable = true;
        }
        else
        {
            if (genCtr.toDay != data.pLastDailyClaim)
            {
                //New day access + unclaimed
                for (int i = 0; i < rewardBtn.Count; i++)
                {
                    rewardBtn[streakDaily].GetComponent<Button>().interactable = false;
                }

                if (streakDaily >= 1 && streakDaily < 8)
                {
                    //Lock previous day claim buttons
                    for (int i = 0; i < streakDaily; i++)
                    {
                        rewardBtn[i].GetComponent<Button>().interactable = false;
                    }

                    for (int j = streakDaily + 1; j > rewardBtn.Count; j++)
                    {
                        rewardBtn[j].GetComponent<Button>().interactable = false;
                    }
                    rewardBtn[streakDaily].GetComponent<Button>().interactable = true;

                    isAllowDailyClaim = false;
                }
            }
            else if (genCtr.toDay == data.pLastDailyClaim)
            {
                if (data.pAllowClaimDaily == 1)
                {
                    //Same day access + claimed
                    isAllowDailyClaim = false;
                    for (int i = 0; i < rewardBtn.Count; i++)
                    {
                        rewardBtn[i].GetComponent<Button>().interactable = false;
                    }
                }
                else if (data.pAllowClaimDaily == 0)
                {
                    //Same day, unclaimed
                    isAllowDailyClaim = true;
                    for (int i = 0; i < rewardBtn.Count; i++)
                    {
                        rewardBtn[i].GetComponent<Button>().interactable = false;
                    }
                    rewardBtn[streakDaily].GetComponent<Button>().interactable = true; //Enable only able-to-claim button
                }
            }
        }
    }
    public void OnClaimDaily()
    {
        int tempFinalScoreToOverride;
        SelectRewardDaily();
        rewardBtn[streakDaily].GetComponent<Button>().interactable = false;
        lastCollectDay = DateTime.Today.Day.ToString();
        isAllowDailyClaim = false;
        tempFinalScoreToOverride = rewardToGive;
        streakDaily++;
        data.UpdateAllowClaimDaily(1);

        print("tempFinalScoreToOverride = " + tempFinalScoreToOverride);

        data.UpdatePlayerEconomics(1, tempFinalScoreToOverride,0); // Update score
        data.UpdateStreak(streakDaily); //Update streak
        data.UpdatePatrolDailyReward(lastCollectDay); //Update last collect day
        ShowRewardDaily();
        menu.OnUserInfor();
    }
    private void SelectRewardDaily()
    {
        switch (streakDaily)
        {
            case 0:
                baseReward = 10;
                break;
            case 1:
                baseReward = 20;
                break;
            case 2:
                baseReward = 40;
                break;
            case 3:
                baseReward = 80;
                break;
            case 4:
                baseReward = 160;
                break;
            case 5:
                baseReward = 320;
                break;
            case 6:
                baseReward = 640;
                break;
            case 7:
                baseReward = 1280;
                OnResetStreak();
                break;
        }
    }
    #endregion
    private void OnCheckDailyClaimOnInit()
    {
        if (genCtr.toDay != data.pLastDailyClaim)
        {
            data.UpdateAllowClaimDaily(0);
            isAllowDailyClaim = true;
        }
        else
        {
            isAllowDailyClaim = false;
        }
    }
    private void OnResetStreak()
    {
        //Reset streak
        data.UpdateStreak(0); //Update streak
        data.UpdatePatrolDailyReward(""); //Update last collect day
    }
}
