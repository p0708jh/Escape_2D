using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayReward : MonoBehaviour
{
    string sceneName;
    Button button;

    // Use this for initialization
    void Start()
    {
        button = this.transform.GetComponent<Button>();
        button.onClick.AddListener(Play);
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Play()
    {
        GameObject.Find("GameManager").GetComponent<AdmobManager>().ShowRewardAd();// reward 광고 띄우기

    }
}
