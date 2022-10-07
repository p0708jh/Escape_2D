using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using System;

public class AdmobManager : MonoBehaviour
{
    public bool isTestMode;
    //public Button FrontAd, RewardAd;

    void Start()
    {
        LoadBannerAd();
        LoadFrontAd();
        LoadRewardAd();
    }
    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "Main" || SceneManager.GetActiveScene().name == "Chapter" || SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "StageClear")
        {
            if (SceneManager.GetActiveScene().name == "Main" || SceneManager.GetActiveScene().name == "Chapter")
                bannerAd.SetPosition(AdPosition.Bottom);
            else
                bannerAd.SetPosition(AdPosition.Top);
            ToggleBannerAd(true);
            if (SceneManager.GetActiveScene().name == "StageClear")
            {
                if (GameObject.Find("StageManager").GetComponent<StageManager>().stageNumber >= 3 && GameObject.Find("StageManager").GetComponent<StageManager>().stageNumber % 3 == 0 && StageManager.mode == "normal")
                    ShowFrontAd();
            }
        }
        else
        {
            ToggleBannerAd(false);
        }
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {

        //FrontAd.interactable = frontAd.IsLoaded();
        //RewardAd.interactable = rewardAd.IsLoaded();
    }



    AdRequest GetAdRequest()
    {
        return new AdRequest.Builder().AddTestDevice("54127C3AB0A3368A").Build();
    }

    #region 배너 광고
#if UNITY_IOS
    const string bannerTestID = "ca-app-pub-3940256099942544/2934735716";
    const string bannerID = "ca-app-pub-3476015118616333/6883136188";
#else
    const string bannerTestID = "ca-app-pub-3940256099942544/6300978111";
    const string bannerID = "ca-app-pub-3476015118616333/8478492721";
#endif
    BannerView bannerAd;

    void LoadBannerAd()
    {
        bannerAd = new BannerView(isTestMode ? bannerTestID : bannerID, AdSize.Banner, AdPosition.Bottom);


        bannerAd.LoadAd(GetAdRequest());
        ToggleBannerAd(false);
    }

    public void ToggleBannerAd(bool b)
    {
        if (b)
        {
            //bannerAd.LoadAd(GetAdRequest());
            bannerAd.Show();
        }
        else bannerAd.Hide();
    }

    #endregion

    #region 전면 광고
#if UNITY_IOS
    const string frontTestID = "ca-app-pub-3940256099942544/4411468910";
    const string frontID = "ca-app-pub-3476015118616333/4256972848";
#else
    const string frontTestID = "ca-app-pub-3940256099942544/1033173712";
    const string frontID = "ca-app-pub-3476015118616333/6932093870";
#endif
    InterstitialAd frontAd;

    void LoadFrontAd()
    {
        frontAd = new InterstitialAd(isTestMode ? frontTestID : frontID);
        frontAd.LoadAd(GetAdRequest());
        frontAd.OnAdClosed += (sender, e) =>
         {
             Debug.Log("전면광고 성공");
         };
    }

    public void ShowFrontAd()
    {
        frontAd.Show();
        LoadFrontAd();
    }

    #endregion

    #region 리워드 광고
#if UNITY_IOS
    const string rewardTestID = "ca-app-pub-3940256099942544/1712485313";
    const string rewardID = "ca-app-pub-3476015118616333/2943891174";
#else
    const string rewardTestID = "ca-app-pub-3940256099942544/5224354917";
    const string rewardID = "ca-app-pub-3476015118616333/9761985932";
#endif
    RewardedAd rewardAd;

    void LoadRewardAd()
    {
        rewardAd = new RewardedAd(isTestMode ? rewardTestID : rewardID);
        rewardAd.LoadAd(GetAdRequest());
        rewardAd.OnUserEarnedReward += (sender, e) =>
        {
            GameObject.Find("UiCanvas").transform.GetChild(5).gameObject.SetActive(true); // 리워드 후 일시정지 버튼 활성화
            GameObject.Find("UiCanvas").transform.GetChild(5).GetComponent<Pause>().Paused(); // 리워드 후 일시정지 작동
            Debug.Log("리워드 광고 성공");
            StageManager.lastchance = 0;
            SceneManager.LoadScene(Convert.ToString("Stage" + StageManager.retryNumber));//GameObject.Find("StageManager").GetComponent<StageManager>().stageNumber
            GameObject.Find("GameManager").GetComponent<ButtonSound>().PlayClear();
        };
    }

    public void ShowRewardAd()
    {
        rewardAd.Show();
        LoadRewardAd();
    }

    #endregion
}
