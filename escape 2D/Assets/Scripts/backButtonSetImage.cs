using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backButtonSetImage : MonoBehaviour
{
    Button button;
    public Sprite changeImage;
    // Start is called before the first frame update
    void Start()
    {
        button = this.transform.GetComponent<Button>();
        button.onClick.AddListener(Set);
    }

   
    private void Set()
    {
        GameObject.Find("UI").transform.GetChild(4).GetComponent<Image>().sprite = changeImage; // Back button
    }
    
}
