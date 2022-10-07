using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    
    public static float PlayTime=0;
    public static float PlayTime2 = 0;
    public static float LimitTime=0;
    public Text PlayTimerText;
    public Text LimitTimerText;
    public GameObject m_joystick;
    void Start()
    {

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            PlayTime = 0;
            LimitTime = 300;
        }

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "Stage1" && StageManager.mode == "timeattack")
        {
            PlayTime = 0;
            PlayTime2 = 0;
            LimitTime = 300;
        }
        else if (SceneManager.GetActiveScene().name != "StageClear" && StageManager.mode == "normal")
        {
            PlayTime = 0;
            LimitTime = 300;
        }
        else if (SceneManager.GetActiveScene().name != "StageClear")
        {
            PlayTime2 = 0;
        }

        

        if (SceneManager.GetActiveScene().name == "Main")
        {
            GameObject.Find("UI").transform.GetChild(0).transform.localPosition = new Vector3(-200, -350, 0); // START
            GameObject.Find("UI").transform.GetChild(1).transform.localPosition = new Vector3(200, -350, 0); // EXIT
            GameObject.Find("UI").transform.GetChild(3).transform.localPosition = new Vector3(1000, -450, 0); // BACK
            GameObject.Find("UI").transform.GetChild(6).transform.localPosition = new Vector3(500, -330, 0); // Donation
            //GameObject.Find("UI").transform.GetChild(2).transform.localPosition = new Vector3(770, 430, 0); // Ranking

            GameObject.Find("UI").transform.GetChild(0).gameObject.SetActive(true); // START
            GameObject.Find("UI").transform.GetChild(1).gameObject.SetActive(true); // EXIT
            //GameObject.Find("UI").transform.GetChild(2).gameObject.SetActive(true); // Ranking
            GameObject.Find("UI").transform.GetChild(4).gameObject.SetActive(true); // Login
            GameObject.Find("UI").transform.GetChild(6).gameObject.SetActive(true); // Donation

            //GameObject.Find("UiCanvas").transform.GetChild(2).gameObject.SetActive(false); // JoyStic
            GameObject.Find("UiCanvas").transform.GetChild(2).gameObject.SetActive(false); // Time
            GameObject.Find("UiCanvas").transform.GetChild(4).gameObject.SetActive(true); // Logo
        }

        if (SceneManager.GetActiveScene().name != "Main" && SceneManager.GetActiveScene().name != "Chapter" && SceneManager.GetActiveScene().name != "GameOver" && SceneManager.GetActiveScene().name != "Ranking" && SceneManager.GetActiveScene().name != "StageClear" && SceneManager.GetActiveScene().name != "TheEnd")
        {
            //GameObject.Find("UiCanvas").transform.GetChild(2).gameObject.SetActive(true);// JoyStic
            GameObject.Find("UiCanvas").transform.GetChild(2).gameObject.SetActive(true);// Time
            GameObject joystic = (GameObject)Instantiate(m_joystick, Vector3.zero, Quaternion.identity);
        }
        /*else
        {
            //GameObject.Find("UiCanvas").transform.GetChild(2).gameObject.SetActive(false);
            GameObject.Find("UiCanvas").transform.GetChild(2).gameObject.SetActive(false);
            Destroy(m_joystick);

        }
        */
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    // Update is called once per frame
    void Update()
    {
        /*
        if(SceneManager.GetActiveScene().name == "Main"  || SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "Ranking" || SceneManager.GetActiveScene().name == "StageClear" || SceneManager.GetActiveScene().name == "TheEnd")
            StageManager.playing = false;
        else
            StageManager.playing = true;
        */
        if (StageManager.playing)
        {
            PlayTime += Time.deltaTime;
            PlayTime2 += Time.deltaTime;
            LimitTime -= Time.deltaTime;
        }

        PlayTimerText.text = "Time : " + (Mathf.Round(PlayTime * 10) / 10);
        LimitTimerText.text = "Time : " + (Mathf.Round(LimitTime * 1000) / 1000);
    }
}
