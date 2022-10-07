using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePaint : MonoBehaviour
{
    public Text playTime;
    public Text limitTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playTime.text = GameObject.Find("Timer").GetComponent<Timer>().PlayTimerText.text;
        limitTime.text = GameObject.Find("Timer").GetComponent<Timer>().LimitTimerText.text;

    }
}
