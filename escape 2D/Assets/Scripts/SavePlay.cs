using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SavePlay : MonoBehaviour
{
    string SceneName;
    Button button;
    // Use this for initialization 1830 -175 = 1655
    void Start()
    {
        SceneName = transform.name;
        button = this.transform.GetComponent<Button>();
        button.onClick.AddListener(Play);

        //GameObject.Find("UI").transform.SetAsFirstSibling();


    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Play()
    {
        //GameObject.Find("UiCanvas").transform.GetChild(3).gameObject.SetActive(true); //Time
        
        SceneManager.LoadScene(SceneName);
    }
}
