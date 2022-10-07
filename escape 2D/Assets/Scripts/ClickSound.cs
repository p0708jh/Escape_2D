using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSound : MonoBehaviour
{
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = this.transform.GetComponent<Button>();
        button.onClick.AddListener(Play);
    }

    // Update is called once per frame
    public void Play()
    {
        GameObject.Find("GameManager").GetComponent<ButtonSound>().PlayClick();
    }
}
