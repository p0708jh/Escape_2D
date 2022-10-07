using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Next : MonoBehaviour {

    string sceneName;
    Button button;

    // Use this for initialization
    void Start () {
        button = this.transform.GetComponent<Button>();
        button.onClick.AddListener(NextStage);
    }
	
	// Update is called once per frame
	void Update () {
        

    }

    public void NextStage()
    {
        sceneName = Convert.ToString("Stage" + (GameObject.Find("StageManager").GetComponent<StageManager>().stageNumber+1));
        Debug.Log(sceneName);
        if(sceneName == "Stage31")
            SceneManager.LoadScene("TheEnd");
        else
            SceneManager.LoadScene(sceneName);

        GameObject.Find("StageText").SetActive(false);
        GameObject.Find("UI").transform.GetChild(1).gameObject.SetActive(false); // EXIT
        GameObject.Find("UI").transform.GetChild(2).gameObject.SetActive(false); // NEXT
        GameObject.Find("UI").transform.GetChild(6).gameObject.SetActive(false); // Donation
    }
}
