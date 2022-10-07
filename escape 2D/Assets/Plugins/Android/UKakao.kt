package com.company.escape2d

import android.os.UserManager
import android.util.Log
import com.kakao.sdk.auth.LoginClient
import com.kakao.sdk.auth.model.OAuthToken
import com.kakao.sdk.user.UserApiClient
import com.kakao.sdk.user.model.Account
import com.kakao.sdk.user.model.Profile
import com.kakao.sdk.user.model.User
import com.unity3d.player.UnityPlayer
import android.content.Context
import com.kakao.sdk.common.KakaoSdk

class UKakao {
    data class USER(val nickname: String, val EMAIL: String)

    fun KakaoLogin() {
        //로그인 공통 callback 구성
        Logout() // 먼저 무조건 로그아웃

        //로그인
        val callback: (OAuthToken?, Throwable?) -> Unit = { token, error ->
            if (error != null) {
                Log.e("aaaaa", "로그인 실패", error)
            } else if (token != null) {
                Log.i("옹예에엥ㅇ", "로그인 성공 ${token.accessToken}")
                Getme()
            }
        }



        // 카카오톡이 설치되어 있으면 카카오톡으로 로그인, 아니면 카카오계정으로 로그인
        if (LoginClient.instance.isKakaoTalkLoginAvailable(UnityPlayer.currentActivity)) {
            LoginClient.instance.loginWithKakaoTalk(UnityPlayer.currentActivity,
                callback = callback
            )
        } else {
            LoginClient.instance.loginWithKakaoAccount(
                UnityPlayer.currentActivity,
                callback = callback
            )
        }

    }


    // 유저정보를 Json 형태로 받아와 스트링으로 유니티에 전달
fun Getme(){
        UserApiClient.instance.me { user, error ->
            if (error != null)
            {
                Log.e("정보 요청 실패야", "사용자 정보 요청 실패", error)
            }
            else if (user != null)
            {

                Log.i("정보 요청 성공이다!", "사용자 정보 요청 성공" +
                        "\n회원번호: ${user.id}" +
                        "\n이메일: ${user.kakaoAccount?.email}" +
                        "\n닉네임: ${user.kakaoAccount?.profile?.nickname}" +
                        "\n프로필사진: ${user.kakaoAccount?.profile?.profileImageUrl}")

                //return USER(user.kakaoAccount?.profile?.nickname, user.kakaoAccount?.email);
                var list = ArrayList<String>()
                list.add("${user.kakaoAccount?.profile?.nickname}")
                list.add("${user.kakaoAccount?.email}")
                list.add("${user.kakaoAccount?.profile?.profileImageUrl}")

                UnityPlayer.UnitySendMessage("GameManager","SetName",list[0]) //이름 유니티 게임오브젝트에 값을 전달하는 방법
                UnityPlayer.UnitySendMessage("GameManager","SetEmail",list[1]) // email
                UnityPlayer.UnitySendMessage("GameManager","SetImage",list[2]) // 프로필사진
            }

        }

    }

    fun Logout() {
        UserApiClient.instance.logout{ error ->
            if (error != null) {
                Log.e("로그아웃 실패", "로그아웃 실패. SDK에서 토큰 삭제됨", error)
            } else {
                Log.i("로그아웃 성공", "로그아웃 성공. SDK에서 토큰 삭제됨")
            }
        }
    }




}