using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StageInfo : MonoBehaviour
{
    string stageName;
    int stageNumber;
    float stageClearTime;
    string star;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GetInfo());
    }

    private void Update()
    {
        /*
        if (GetSave.infoGetDone)
        {
            StartCoroutine(GetInfo());
            GetSave.infoGetDone = false;
        }
        */
    }
    /*
    private void OnDisable()
    {
        StartCoroutine(GetInfo());
    }
    */
    private void OnEnable()
    {
        StartCoroutine(GetInfo());
    }
    private IEnumerator GetInfo()
    {
        stageName = transform.parent.name;
        stageNumber = Convert.ToInt32(stageName.Split(new string[] { "Stage" }, StringSplitOptions.RemoveEmptyEntries)[0]);

        yield return new WaitUntil(() => GetSave.infoGetDone == true);

        /*
        {
            Debug.Log("null 일때" + GetSave.stageClearTime.Count);
            StartCoroutine(GetInfo());
        }
        */
        transform.GetComponent<Text>().text = stageName + "\n\n"+ "☆ ☆ ☆" + "\n\n";
        if (GetSave.stageClearTime.Count != 1 && GetSave.stageClearTime.Count>stageNumber)
        {
            Debug.Log("null 아닐때" + GetSave.stageClearTime.Count);

            stageClearTime = GetSave.stageClearTime[stageNumber];

            if (stageClearTime <= StageManager.stageDifficulty[stageNumber, 0])
                star = "★ ★ ★";
            else if (stageClearTime <= StageManager.stageDifficulty[stageNumber, 1])
                star = "★ ★ ☆";
            else if (stageClearTime <= StageManager.stageDifficulty[stageNumber, 2])
                star = "★ ☆ ☆";
            else
                star = "☆ ☆ ☆";

            transform.GetComponent<Text>().text = stageName + "\n\n" + star + "\n\n" + stageClearTime;
        }


        


       // yield return null;
    }

}
