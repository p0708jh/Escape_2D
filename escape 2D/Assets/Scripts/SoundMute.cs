using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundMute : MonoBehaviour
{

    public Sprite speaker;
    public Sprite mute;
    bool play=true;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = this.transform.GetComponent<Button>();
        button.onClick.AddListener(Mute);
    }

    public void Mute()
    {
        if (play == true)
        {
            transform.GetComponent<Image>().sprite = mute;
            GameObject.Find("GameManager").GetComponent<AudioSource>().mute = true;
            play = false;
        }
        else if (play == false)
        {
            transform.GetComponent<Image>().sprite = speaker;
            GameObject.Find("GameManager").GetComponent<AudioSource>().mute = false;
            play = true;
        }
    }
}
