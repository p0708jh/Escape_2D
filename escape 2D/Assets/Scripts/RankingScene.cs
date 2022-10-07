using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RankingScene : MonoBehaviour
{
    public int SceneNumber;
    public GameObject button;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Next()
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
