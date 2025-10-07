using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.LevelPlay;

public class AdsMN : MonoBehaviour
{
    private LevelPlayBannerAd bannerAds;
    private LevelPlayRewardedAd rewardAds;
    private LevelPlayInterstitialAd interstitalAds;

    bool isAdsEnable = false;
    void Start()
    {
        LevelPlay.ValidateIntegration();
        LevelPlay.OnInitSuccess += SdkInitializationCompletedEvent;
        LevelPlay.OnInitFailed += SdkInitializationFailedEvent;
        LevelPlay.Init(AdConfig.AppKey);
    }
    void EnableAds()
    {
        //Register to ImpressionDataReadyEvent
        LevelPlay.OnImpressionDataReady += ImpressionDataReadyEvent;

        //Create Rewarded Video object
        rewardAds = new LevelPlayRewardedAd(AdConfig.RewardedVideoAdUnitId);

        //Register to Rewarded Video events
        rewardAds.OnAdLoaded += RewardedVideoOnLoadedEvent;
        rewardAds.OnAdLoadFailed += RewardedVideoOnAdLoadFailedEvent;
        rewardAds.OnAdDisplayed += RewardedVideoOnAdDisplayedEvent;
        rewardAds.OnAdDisplayFailed += RewardedVideoOnAdDisplayedFailedEvent;
        rewardAds.OnAdRewarded += RewardedVideoOnAdRewardedEvent;
        rewardAds.OnAdClicked += RewardedVideoOnAdClickedEvent;
        rewardAds.OnAdClosed += RewardedVideoOnAdClosedEvent;
        rewardAds.OnAdInfoChanged += RewardedVideoOnAdInfoChangedEvent;

        //Create Banner object
        bannerAds = new LevelPlayBannerAd(AdConfig.BannerAdUnitId);

        //Register to Banner events
        bannerAds.OnAdLoaded += BannerOnAdLoadedEvent;
        bannerAds.OnAdLoadFailed += BannerOnAdLoadFailedEvent;
        bannerAds.OnAdDisplayed += BannerOnAdDisplayedEvent;
        bannerAds.OnAdDisplayFailed += BannerOnAdDisplayFailedEvent;
        bannerAds.OnAdClicked += BannerOnAdClickedEvent;
        bannerAds.OnAdCollapsed += BannerOnAdCollapsedEvent;
        bannerAds.OnAdLeftApplication += BannerOnAdLeftApplicationEvent;
        bannerAds.OnAdExpanded += BannerOnAdExpandedEvent;

        //Create Interstitial object
        interstitalAds = new LevelPlayInterstitialAd(AdConfig.InterstitalAdUnitId);

        //Register to Interstitial events
        interstitalAds.OnAdLoaded += InterstitialOnAdLoadedEvent;
        interstitalAds.OnAdLoadFailed += InterstitialOnAdLoadFailedEvent;
        interstitalAds.OnAdDisplayed += InterstitialOnAdDisplayedEvent;
        interstitalAds.OnAdDisplayFailed += InterstitialOnAdDisplayFailedEvent;
        interstitalAds.OnAdClicked += InterstitialOnAdClickedEvent;
        interstitalAds.OnAdClosed += InterstitialOnAdClosedEvent;
        interstitalAds.OnAdInfoChanged += InterstitialOnAdInfoChangedEvent;

        LoadAds(); //Load Advertisment
    }
    #region Init callback handlers
    void SdkInitializationCompletedEvent(LevelPlayConfiguration config)
    {
        Debug.Log($"[LevelPlaySample] Received SdkInitializationCompletedEvent with Config: {config}");
        EnableAds();
        isAdsEnable = true;
    }
    void SdkInitializationFailedEvent(LevelPlayInitError error) => Debug.Log($"[LevelPlaySample] Received SdkInitializationFailedEvent with Error: {error}");
    #endregion

    private void LoadAds()
    {
        bannerAds.LoadAd();
        rewardAds.LoadAd();
        interstitalAds.LoadAd();

        ShowAds(1);
    }

    public void ShowAds(int adsID)
    {
        print("3. in first open");
        switch (adsID)
        {
            case 1: //Load Banner
                StartCoroutine(WaitToShowBanner());
                break;
            case 2: //Load Reward
                rewardAds.ShowAd();
                break;
            case 3: //Load Inter
                interstitalAds.ShowAd();
                break;
        }
    }

    private IEnumerator WaitToShowBanner()
    {
        yield return new WaitForSeconds(3);
        bannerAds.ShowAd();
    }

    #region AdInfo Rewarded Video
    void RewardedVideoOnLoadedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received RewardedVideoOnLoadedEvent With AdInfo: {adInfo}");
    }

    void RewardedVideoOnAdLoadFailedEvent(LevelPlayAdError error)
    {
        Debug.Log($"[LevelPlaySample] Received RewardedVideoOnAdLoadFailedEvent With Error: {error}");
    }

    void RewardedVideoOnAdDisplayedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received RewardedVideoOnAdDisplayedEvent With AdInfo: {adInfo}");
    }
#pragma warning disable 0618
    void RewardedVideoOnAdDisplayedFailedEvent(LevelPlayAdDisplayInfoError error)
    {
        Debug.Log($"[LevelPlaySample] Received RewardedVideoOnAdDisplayedFailedEvent With Error: {error}");
    }
#pragma warning restore 0618
    void RewardedVideoOnAdRewardedEvent(LevelPlayAdInfo adInfo, LevelPlayReward reward)
    {
        Debug.Log($"[LevelPlaySample] Received RewardedVideoOnAdRewardedEvent With AdInfo: {adInfo} and Reward: {reward}");
    }

    void RewardedVideoOnAdClickedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received RewardedVideoOnAdClickedEvent With AdInfo: {adInfo}");
    }

    void RewardedVideoOnAdClosedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received RewardedVideoOnAdClosedEvent With AdInfo: {adInfo}");
    }

    void RewardedVideoOnAdInfoChangedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received RewardedVideoOnAdInfoChangedEvent With AdInfo {adInfo}");
    }

    #endregion

    #region AdInfo Interstitial

    void InterstitialOnAdLoadedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdLoadedEvent With AdInfo: {adInfo}");
    }

    void InterstitialOnAdLoadFailedEvent(LevelPlayAdError error)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdLoadFailedEvent With Error: {error}");
    }

    void InterstitialOnAdDisplayedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdDisplayedEvent With AdInfo: {adInfo}");
    }
#pragma warning disable 0618
    void InterstitialOnAdDisplayFailedEvent(LevelPlayAdDisplayInfoError infoError)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdDisplayFailedEvent With InfoError: {infoError}");
    }
#pragma warning restore 0618
    void InterstitialOnAdClickedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdClickedEvent With AdInfo: {adInfo}");
    }

    void InterstitialOnAdClosedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdClosedEvent With AdInfo: {adInfo}");
    }

    void InterstitialOnAdInfoChangedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdInfoChangedEvent With AdInfo: {adInfo}");
    }

    #endregion

    #region Banner AdInfo
    void BannerOnAdLoadedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received BannerOnAdLoadedEvent With AdInfo: {adInfo}");
    }

    void BannerOnAdLoadFailedEvent(LevelPlayAdError error)
    {
        Debug.Log($"[LevelPlaySample] Received BannerOnAdLoadFailedEvent With Error: {error}");
    }

    void BannerOnAdClickedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received BannerOnAdClickedEvent With AdInfo: {adInfo}");
    }

    void BannerOnAdDisplayedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received BannerOnAdDisplayedEvent With AdInfo: {adInfo}");
    }
#pragma warning disable 0618
    void BannerOnAdDisplayFailedEvent(LevelPlayAdDisplayInfoError adInfoError)
    {
        Debug.Log($"[LevelPlaySample] Received BannerOnAdDisplayFailedEvent With AdInfoError: {adInfoError}");
    }
#pragma warning restore 0618
    void BannerOnAdCollapsedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received BannerOnAdCollapsedEvent With AdInfo: {adInfo}");
    }

    void BannerOnAdLeftApplicationEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received BannerOnAdLeftApplicationEvent With AdInfo: {adInfo}");
    }

    void BannerOnAdExpandedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received BannerOnAdExpandedEvent With AdInfo: {adInfo}");
    }

    #endregion

    #region ImpressionSuccess callback handler
    void ImpressionDataReadyEvent(LevelPlayImpressionData impressionData)
    {
        Debug.Log($"[LevelPlaySample] Received ImpressionDataReadyEvent ToString(): {impressionData}");
        Debug.Log($"[LevelPlaySample] Received ImpressionDataReadyEvent allData: {impressionData.AllData}");
    }
    #endregion
}
