using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Pause : MonoBehaviour
{

    bool IsPause;
    Button button;
    // Use this for initialization
    void Start()
    {
        button = this.transform.GetComponent<Button>();
        button.onClick.AddListener(Paused);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC눌러따!");
            Paused();
        }
    }

    public void Paused()
    {
        /*일시정지 활성화*/
        if (IsPause == false)
        {
            Time.timeScale = 0;
            foreach (Transform child in GameObject.Find("UiCanvas").transform.GetChild(5).transform) // 옵션패널
            {
                child.gameObject.SetActive(true);                
            }
            IsPause = true;
            return;
        }

        /*일시정지 비활성화*/
        if (IsPause == true)
        {
            Time.timeScale = 1;
            foreach (Transform child in GameObject.Find("UiCanvas").transform.GetChild(5).transform)
            {
                child.gameObject.SetActive(false);
            }
            IsPause = false;
            return;
        }
    }
}