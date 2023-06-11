using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    private const string ANDROID_GAME_ID = "5310396";
    private const string ANDROID_INTERSTITIAL_AD_ID = "Interstitial_Android";
    private const string ANDROID_BANNER_AD_ID = "Banner_Android";
    private const string ANDROID_REWARD_AD_ID = "Rewarded_Android";
    
    private const string IOS_GAME_ID = "5310397";
    private const string IOS_INTERSTITIAL_AD_ID = "Interstitial_iOS";
    private const string IOS_BANNER_AD_ID = "Banner_iOS";
    private const string IOS_REWARD_AD_ID = "Rewarded_iOS";
    
    [SerializeField] private Button activateAdButton;
    
    private string currentTargetAdid;

    public void ShowAd()
    {
        Advertisement.Show(currentTargetAdid, this);
    }

    #region Initialization

    public void OnInitializationComplete()
    {
        Debug.Log("Ads are ready!");
        currentTargetAdid = GetBannerAdID();
        Advertisement.Load(currentTargetAdid, this);
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError(error.ToString() + Environment.NewLine + message);
    }

    #endregion

    #region AdLoad

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ad " + placementId + " is ready");
        activateAdButton.interactable = true;
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError("Ad " + placementId + " did not load successfully " +  Environment.NewLine + error + Environment.NewLine + message);
    }

    #endregion


    #region AdShow

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError("Ad " + placementId + " did not show successfully " +  Environment.NewLine + error + Environment.NewLine + message);
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("What is it?");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Ad " + placementId + " finished " + showCompletionState);
    }

    #endregion

    
    void Start()
    {
        Advertisement.Initialize(GetPlatformGameCode(), true, this);
    }

    string GetPlatformGameCode()
    {
#if UNITY_IOS
        return IOS_GAME_ID;
#elif UNITY_ANDROID
        return ANDROID_GAME_ID;
#endif
    }

    string GetInterstitialAdID()
    {
#if UNITY_IOS
        return IOS_INTERSTITIAL_AD_ID;
#elif UNITY_ANDROID
        return ANDROID_INTERSTITIAL_AD_ID;
#endif
    }
    
    string GetBannerAdID()
    {
#if UNITY_IOS
        return IOS_BANNER_AD_ID;
#elif UNITY_ANDROID
        return ANDROID_BANNER_AD_ID;
#endif
    }


   
}
