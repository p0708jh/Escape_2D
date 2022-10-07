using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    public string ScenName;
    Button button;
    // Use this for initialization 1830 -175 = 1655
    void Start () {
        
        button = this.transform.GetComponent<Button>();
        button.onClick.AddListener(Next);

        //GameObject.Find("UI").transform.SetAsFirstSibling();

        
    }
	
	// Update is called once per frame
	void Update () {
        

    }

    public void Next()
    {
        //GameObject.Find("UiCanvas").transform.GetChild(3).gameObject.SetActive(true); //Time
        if (ScenName == "Ranking")
        {
            GameObject.Find("UiCanvas").transform.GetChild(2).gameObject.SetActive(false); //Time
            GameObject.Find("UI").transform.GetChild(3).gameObject.SetActive(true); //Back
        }
        SceneManager.LoadScene(ScenName);
    }
}
