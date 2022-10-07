using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public int stageNumber;
    public static bool playing;
    public static int retryNumber;

    public static int lastchance = 1; 

    static public string mode = "normal";
    public int saveStage = 0;
    public static float[,] stageDifficulty =
      {    
        {0,0,0,},
        { 4.0f, 8.0f, 16.0f },  //stage1 클리어 별 시간초
        { 4.5f, 9f, 13.5f },  //stage2 클리어 별 시간초 
        { 16f, 32f, 48f },  //stage3 클리어 별 시간초 
        { 9f, 18f, 27f },  //stage4 클리어 별 시간초 
        { 11f, 22f, 33f },  //stage5 클리어 별 시간초 
        { 33f, 66f, 99f },  //stage6 클리어 별 시간초 
        { 60f, 120f, 180f },  //stage7 클리어 별 시간초 
        { 15f, 20f, 25f },  //stage8 클리어 별 시간초 
        { 60f, 80f, 100f },  //stage9 클리어 별 시간초 
        { 20f, 30f, 40f },  //stage10 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage11 클리어 별 시간초 
        { 30f, 50f, 70f },  //stage12 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage11 클리어 별 시간초
        { 20f, 40f, 60f },  //stage12 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage13 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage14 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage15 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage16 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage17 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage18 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage19 클리어 별 시간초 
        { 20f, 30f, 40f },  //stage20 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage21 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage22 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage23 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage24 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage25 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage26 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage27 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage28 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage29 클리어 별 시간초 
        { 20f, 30f, 40f },  //stage30 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage31 클리어 별 시간초 
        { 30f, 50f, 70f },  //stage32 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage33 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage34 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage35 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage36 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage37 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage38 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage39 클리어 별 시간초               
        { 20f, 30f, 40f },  //stage40 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage41 클리어 별 시간초 
        { 30f, 50f, 70f },  //stage42 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage43 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage44 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage45 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage46 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage47 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage48 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage49 클리어 별 시간초 
        { 20f, 30f, 40f },  //stage50 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage51 클리어 별 시간초 
        { 30f, 50f, 70f },  //stage52 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage53 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage54 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage55 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage56 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage57 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage58 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage59 클리어 별 시간초               
        { 20f, 30f, 40f },  //stage60 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage61 클리어 별 시간초 
        { 30f, 50f, 70f },  //stage62 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage63 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage64 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage65 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage66 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage67 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage68 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage69 클리어 별 시간초 
        { 20f, 30f, 40f },  //stage70 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage71 클리어 별 시간초 
        { 30f, 50f, 70f },  //stage72 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage73 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage74 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage75 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage76 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage77 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage78 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage79 클리어 별 시간초            
        { 20f, 30f, 40f },  //stage80 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage81 클리어 별 시간초 
        { 30f, 50f, 70f },  //stage82 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage83 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage84 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage85 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage86 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage87 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage88 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage89 클리어 별 시간초 
        { 20f, 30f, 40f },  //stage90 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage91 클리어 별 시간초 
        { 30f, 50f, 70f },  //stage92 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage93 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage94 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage95 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage96 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage97 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage98 클리어 별 시간초 
        { 20f, 40f, 60f },  //stage99 클리어 별 시간초 

    };
    // public string [] test;


    // Start is called before the first frame update
    void Start()
    {
        stageNumber = 0;
        retryNumber = 0;
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Main" && SceneManager.GetActiveScene().name != "Chapter" && SceneManager.GetActiveScene().name != "GameOver" && SceneManager.GetActiveScene().name != "Ranking" && SceneManager.GetActiveScene().name != "StageClear")
        {
            playing = true;
            if (SceneManager.GetActiveScene().name != "TheEnd")
            {
                GameObject.Find("UiCanvas").transform.GetChild(5).gameObject.SetActive(true);
                stageNumber = Convert.ToInt32(SceneManager.GetActiveScene().name.Split(new string[] { "Stage" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                retryNumber = Convert.ToInt32(SceneManager.GetActiveScene().name.Split(new string[] { "Stage" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                if (mode == "normal") // Chance 횟수 초기화
                    lastchance = 1;
            }
            //stageNumber = Convert.ToInt32(SceneManager.GetActiveScene().name.Split(stage, StringSplitOptions.RemoveEmptyEntries));
        }
        else
        {
            playing = false;
            GameObject.Find("UiCanvas").transform.GetChild(5).gameObject.SetActive(false);
        }
            
        if (SceneManager.GetActiveScene().name == "Main" || SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "TheEnd")
        { 
            stageNumber = 0;
        }
        if (SceneManager.GetActiveScene().name == "Main")
        {
            lastchance = 1;
        }
           // Debug.Log(stageNumber);
    }
}
