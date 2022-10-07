using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using UnityEngine.UI;
//using System.Threading;

public class clear : MonoBehaviour {
    public int check_need;
    //public GameObject player;
    private string star;
    
    //Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //move_player po = player.GetComponent<move_player>();
        
        if (collision.gameObject.name == "player" && collision.gameObject.GetComponent<move_player>().point == check_need )
        {
            GameObject.Find("GameManager").GetComponent<ButtonSound>().PlayClear();
            SceneManager.LoadScene("StageClear");

            if (StageManager.mode == "normal")
            {
                if (Timer.PlayTime <= StageManager.stageDifficulty[GameObject.Find("StageManager").GetComponent<StageManager>().stageNumber, 0])
                    star = "★ ★ ★";
                else if (Timer.PlayTime <= StageManager.stageDifficulty[GameObject.Find("StageManager").GetComponent<StageManager>().stageNumber, 1])
                    star = "★ ★ ☆";
                else if (Timer.PlayTime <= StageManager.stageDifficulty[GameObject.Find("StageManager").GetComponent<StageManager>().stageNumber, 2])
                    star = "★ ☆ ☆";
                else
                    star = "☆ ☆ ☆";
                GameObject.Find("UiCanvas").transform.GetChild(3).gameObject.GetComponent<Text>().text = Convert.ToString("S T A G E  " + (GameObject.Find("StageManager").GetComponent<StageManager>().stageNumber) + "\n C L E A R !");
                GameObject.Find("UiCanvas").transform.GetChild(3).GetChild(0).gameObject.GetComponent<Text>().text = "\n\n\n\n\n\n\n\n" + star;

            }
            else if (StageManager.mode == "timeattack")
            {
                if (Timer.PlayTime2 <= StageManager.stageDifficulty[GameObject.Find("StageManager").GetComponent<StageManager>().stageNumber, 0])
                    star = "★ ★ ★";
                else if (Timer.PlayTime2 <= StageManager.stageDifficulty[GameObject.Find("StageManager").GetComponent<StageManager>().stageNumber, 1])
                    star = "★ ★ ☆";
                else if (Timer.PlayTime2 <= StageManager.stageDifficulty[GameObject.Find("StageManager").GetComponent<StageManager>().stageNumber, 2])
                    star = "★ ☆ ☆";
                else
                    star = "☆ ☆ ☆";
                GameObject.Find("UiCanvas").transform.GetChild(3).gameObject.GetComponent<Text>().text = Convert.ToString("S T A G E  " + (GameObject.Find("StageManager").GetComponent<StageManager>().stageNumber) + "\n C L E A R !");
                GameObject.Find("UiCanvas").transform.GetChild(3).GetChild(0).gameObject.GetComponent<Text>().text = "\n\n\n\n\n\n\n\n" + star;
            }
            GameObject.Find("UiCanvas").transform.GetChild(3).gameObject.SetActive(true); // Stage Clear Text

            GameObject.Find("UI").transform.GetChild(1).transform.localPosition = new Vector3(350, -400, 0); // EXIT
            GameObject.Find("UI").transform.GetChild(2).transform.localPosition = new Vector3(700, -370, 0); // NEXT
            GameObject.Find("UI").transform.GetChild(6).transform.localPosition = new Vector3(-350, -330, 0); // Donation
            //GameObject.Find("UI").transform.GetChild(1).gameObject.SetActive(true); // EXIT
            GameObject.Find("UI").transform.GetChild(2).gameObject.SetActive(true); // NEXT
            GameObject.Find("UI").transform.GetChild(6).gameObject.SetActive(true); // Donation
        }
    }
}
