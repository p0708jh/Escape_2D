using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour {
    Button button;
    // Use this for initialization
    void Start () {
        button = this.transform.GetComponent<Button>();
        button.onClick.AddListener(Ex);
    }
	
	// Update is called once per frame
	void Update () {
        

    }

    public void Ex()
    {
        Application.Quit();
    }
}
