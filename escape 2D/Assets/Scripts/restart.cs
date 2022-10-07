using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class restart : MonoBehaviour
{
    Button button;
 
    void Start()
    {
        
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
        if (StageManager.mode == "normal")
        {
            if ((StageManager.retryNumber - 1) / 3 < (GetSave.stageClearTime.Count - 1) / 3)
                SceneManager.LoadScene("Stage" + StageManager.retryNumber);
            else
                SceneManager.LoadScene("Stage" + (((StageManager.retryNumber - 1) / 3 * 3) + 1));
        }
        else
            SceneManager.LoadScene("Stage1");
    }
}
