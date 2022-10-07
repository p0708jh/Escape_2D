using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginCheck : MonoBehaviour
{
    bool IsPause;
    Button button;
    // Use this for initialization
    void Start()
    {

        if (FirebaseLogin.Email == "OandOne@gmail.com")
        {
            transform.gameObject.SetActive(true);
            IsPause = true;
        }
        else
        {
            transform.gameObject.SetActive(false);
            IsPause = false;
        }
        button = this.transform.GetComponent<Button>();
        button.onClick.AddListener(Paused);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC눌러따!");
            if(IsPause == true)
            Paused();
        }
    }

    public void Paused()
    {
        /*일시정지 활성화*/
        if (IsPause == false)
        {
            foreach (Transform child in transform) // RetryReward 확인 패널
            {
                child.gameObject.SetActive(true);
            }
            IsPause = true;
            return;
        }

        /*일시정지 비활성화*/
        if (IsPause == true)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            IsPause = false;
            return;
        }
    }
}
