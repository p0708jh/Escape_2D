using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class retry : MonoBehaviour
{
    Button button;
    // Use this for initialization 1830 -175 = 1655
    void Start()
    {
        if (StageManager.mode != "normal")
            transform.gameObject.SetActive(false);
        button = this.transform.GetComponent<Button>();
        button.onClick.AddListener(Re);

        //GameObject.Find("UI").transform.SetAsFirstSibling();


    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Re()
    {
        if (SceneManager.GetActiveScene().name == "StageClear")
        {
            SceneManager.LoadScene("Stage" + GameObject.Find("StageManager").GetComponent<StageManager>().stageNumber);
            GameObject.Find("UI").transform.GetChild(2).gameObject.SetActive(false); // NEXT
            GameObject.Find("UI").transform.GetChild(6).gameObject.SetActive(false); // Donation
            GameObject.Find("StageText").SetActive(false);// StageText
        }//GameObject.Find("UiCanvas").transform.GetChild(3).gameObject.SetActive(true); //Time
        else if ((StageManager.retryNumber - 1) / 3 < (GetSave.stageClearTime.Count - 1) / 3)
            SceneManager.LoadScene("Stage" + StageManager.retryNumber);
        else
            SceneManager.LoadScene("Stage" + (((StageManager.retryNumber - 1) / 3 * 3) + 1));
    }
}
