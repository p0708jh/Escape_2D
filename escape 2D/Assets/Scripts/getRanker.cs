using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using LitJson;
using UnityEngine.SceneManagement;

public class getRanker : MonoBehaviour
{
    //public List<float> SAVE = new List<float>();
    readonly string URL = "https://6mur5vhowg.execute-api.us-east-1.amazonaws.com/2021-01-02/ranking/ranker";
    public Button Ranker;
    public Text RankerNameText;
    public Text RankerStageText;
    public Text RankerClearTimeText;
    string imageUrl;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        //button = this.transform.GetComponent<Button>();
        // button.onClick.AddListener(Next);

        StartCoroutine(GetRanker());
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            StartCoroutine(GetRanker());
        }
    }
            
    IEnumerator GetRanker()
    {
        

        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            //Debug.LogError(www.error);
            StartCoroutine(GetRanker());
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            JsonData userData = JsonMapper.ToObject(www.downloadHandler.text);
            //int count = userData.Count;   
            JsonData itemName = userData["name"];
            JsonData itemStage = userData["stage"];
            JsonData itemClearTime = userData["clearTime"];
            if (JsonDataContainsKey(userData, "imageUrl"))
            {
                JsonData itemimageUrl = userData["imageUrl"];
                imageUrl = itemimageUrl.ToString();
                if (imageUrl.Contains("http://"))
                    imageUrl = imageUrl.Replace("http://", "https://");
            }
            else
            {
                imageUrl = "https://www.oandone.com/images/1.jpg";
            }

            RankerNameText.text = userData["name"].ToString();
            RankerStageText.text = "Stage: " + userData["stage"].ToString();
            RankerClearTimeText.text = "ClearTime: " + userData["clearTime"].ToString();


            using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(imageUrl))
            {
                yield return uwr.SendWebRequest();

                if (uwr.result == UnityWebRequest.Result.ConnectionError)
                {
                    Debug.Log(uwr.error);
                    StartCoroutine(GetRanker());
                }
                else
                {
                    // Get downloaded asset bundle
                    Texture2D texture = DownloadHandlerTexture.GetContent(uwr);
                    Rect rect = new Rect(0, 0, texture.width, texture.height);
                    Ranker.GetComponent<Image>().sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
                    
                }
            }


            //JsonData itemSaveStage = userData["saveStage"];
            //saveStage = itemSaveStage.Count;

                //GameObject.Find("StageManager").GetComponent<StageManager>().saveStage=saveStage;
                /*
                for (int i = 0; i < stageClearTime.Count; i++)
                    userName.text += "\n" + stageClearTime[i].ToString();
                */
        }
    }

    static public bool JsonDataContainsKey(JsonData data, string key) 
    { 
        bool result = false; 
        if (data == null) return result; 
        if (!data.IsObject) 
        { 
            return result; 
        } 
        IDictionary tdictionary = data as IDictionary;
        if (tdictionary == null) 
            return result; 
        if (tdictionary.Contains(key)) 
        { 
            result = true;
        } 
        return result; 
    }

    public void Next()
    {
        //SAVE.Clear();

        
        /*
        for (int i = 0; i < FirebaseLogin.stageClearTime.Count; i++)
            username.text += "\nabc" + Convert.ToString(FirebaseLogin.stageClearTime[i]);

        */
    }
}
