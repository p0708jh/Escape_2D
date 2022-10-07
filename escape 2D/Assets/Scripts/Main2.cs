using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Main2 : MonoBehaviour
{
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = this.transform.GetComponent<Button>();
        button.onClick.AddListener(Next);
    }

    public void Next()
    {
        SceneManager.LoadScene("Main");
        /*
        GameObject.Find("UI").transform.GetChild(0).gameObject.SetActive(false); // START
        GameObject.Find("UI").transform.GetChild(1).gameObject.SetActive(false); // EXIT
        GameObject.Find("UI").transform.GetChild(4).gameObject.SetActive(false); // BACK
        GameObject.Find("UiCanvas").transform.GetChild(5).gameObject.SetActive(false); // Escape2D
        GameObject.Find("UI").transform.GetChild(5).gameObject.SetActive(true); // MENU
        */
    }
}
