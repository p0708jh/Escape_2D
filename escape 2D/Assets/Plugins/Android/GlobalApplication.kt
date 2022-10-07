package com.company.escape2d

import android.app.Application
import com.kakao.sdk.common.KakaoSdk
import com.kakao.sdk.common.util.Utility


class GlobalApplication : Application(){
    override fun onCreate() {
        super.onCreate()
        // 다른 초기화 코드들

        // Kakao SDK 초기화
        KakaoSdk.init(this, "13009e576f32dee932520a3b918048d4")
        val keyHash = Utility.getKeyHash(this)
        println("키 해쉬 : $keyHash")
    }
}