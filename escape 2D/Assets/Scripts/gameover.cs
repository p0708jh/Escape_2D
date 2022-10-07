using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gameover : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.name == "player")
		{
			SceneManager.LoadScene("GameOver");
			StageManager.playing = false;
			GameObject.Find("UiCanvas").transform.GetChild(0).gameObject.SetActive(true); //0번 자식은 UI
            GameObject.Find("UiCanvas").transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
