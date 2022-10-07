using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RstartReward : MonoBehaviour
{
    bool IsPause;
    Button button;
    // Use this for initialization
    void Start()
    {
        
        if (StageManager.mode == "timeattack") // 패널 위치 조정
        {
            //transform.Translate(new Vector3(-250, 0, 0), Space.Self);
            //transform.GetChild(0).Translate(new Vector3(250, 0, 0), Space.Self);
            transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = "You can get the last chance!\nby watching the video ad.";
        }

        if (StageManager.lastchance == 1)
        {
            if (StageManager.mode == "normal")
            {
                if ((StageManager.retryNumber - 1) / 3 < (GetSave.stageClearTime.Count - 1) / 3)
                    transform.gameObject.SetActive(false);
                else
                    transform.gameObject.SetActive(true);


            }
            else
                transform.gameObject.SetActive(true);
        }
        else
            transform.gameObject.SetActive(false);


        button = this.transform.GetComponent<Button>();
        button.onClick.AddListener(Paused);
    }

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
            foreach (Transform child in GameObject.Find("GameOverUi").transform.GetChild(4).transform) // RetryReward 확인 패널
            {
                child.gameObject.SetActive(true);
            }
            IsPause = true;
            return;
        }

        /*일시정지 비활성화*/
        if (IsPause == true)
        {
            foreach (Transform child in GameObject.Find("GameOverUi").transform.GetChild(4).transform)
            {
                child.gameObject.SetActive(false);
            }
            IsPause = false;
            return;
        }
    }
}
