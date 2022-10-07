using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    //Button button;
    public AudioSource effectSource;
    public List<AudioClip> effect;

    private void Start()
    {
        //button = this.transform.GetComponent<Button>();
        //button.onClick.AddListener(Click);
    }

    public void PlayClick()
    {
        effectSource.volume = 1.0f;
        effectSource.PlayOneShot(effect[0]);
    }
    
    public void PlayStart()
    {

        effectSource.volume = 1.0f;
        effectSource.PlayOneShot(effect[1]);
    }

    public void PlayClear()
    {

        effectSource.volume = 1.0f;
        effectSource.PlayOneShot(effect[2]);
    }
    
}
