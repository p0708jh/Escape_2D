using UnityEngine;
using UnityEngine.UI;

public class limit_timer : MonoBehaviour
{
    //public float PlayTime = 0;
    public float LimitTime=0;
    //public Text PlayTimerText;
    public Text LimitTimerText;

    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        //PlayTime += Time.deltaTime;
        LimitTime -= Time.deltaTime;

        //PlayTimerText.text = "Time : " + (Mathf.Round(PlayTime * 1000) / 1000);
        LimitTimerText.text = "Time : " + (Mathf.Round(LimitTime * 10) / 10);
    }
}
