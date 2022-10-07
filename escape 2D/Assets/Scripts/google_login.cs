using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

//전처리기로 os구분 처리
public class google_login : MonoBehaviour
{
    public Text userName;
#if UNITY_ANDROID
    void Start()
    {

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .RequestIdToken()
            .RequestEmail()
            .Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        // 구글 플레이 게임 활성화
        PlayGamesPlatform.Activate();
        
    }


    public void TryGoogleLogin()
    {
        if (!Social.localUser.authenticated) // 로그인 되어 있지 않다면
        {
            Social.localUser.Authenticate(success => // 로그인 시도
            {
                if (success) // 성공하면
                {
                    userName.text = Social.localUser.userName;

                }
                else // 실패하면
                {
                    userName.text = "Fail...";
                }
            });
        }
    }


    public void TryGoogleLogout()
    {
        if (Social.localUser.authenticated) // 로그인 되어 있다면
        {
            PlayGamesPlatform.Instance.SignOut(); // 로그아웃
            userName.text = "Logout";
        }
    }

#endif
}
