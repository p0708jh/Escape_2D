using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Net;
using System.IO;
using System;
using LitJson;
using UnityEngine.SceneManagement;





public class WWW : MonoBehaviour
{
    [System.Serializable]
    public class SendData
    {
        public string name;
        public int stage;
        public float clearTime;
        public string email;
    }

    [System.Serializable]
    public class MemberData
    {
        public string name;
        public int stage;
        public float clearTime;
    }

    public GameObject m_rankPrefab;
    private Transform m_contentRoot;

    readonly string URL = "https://6mur5vhowg.execute-api.us-east-1.amazonaws.com/2021-01-02/ranking";

    
    void Start()
    {
        // Send();
        //StartCoroutine(GetRequest());
        
    }
    
    
    private void Send()
    {
        Debug.Log("보냄");
        //보낼 데이터
        SendData data = new SendData();
        data.name = "박준형222";
        data.stage = 99999999;
        data.clearTime = 1.23f;
        data.email = "oandone@gmail.com";

        // string,byte[]로 변환
        string str = JsonUtility.ToJson(data);
        var bytes = System.Text.Encoding.UTF8.GetBytes(str);

        //주소와 세팅
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.ContentLength = bytes.Length;

        //stream 형식으로 데이터 보내기
        using (var stream = request.GetRequestStream()) {
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
            stream.Close();
        }

        //데이터를 StreamReader로 받음
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();

        //string 값을 JsonUtility로 커스텀 클래스

    }

    
    public void OnButtonGetScore()
    {
        StartCoroutine(GetRequest());
    }

    IEnumerator GetRequest()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            JsonData jsonData = JsonMapper.ToObject(www.downloadHandler.text);
            int count = jsonData.Count;

            for (int i = 0; i < count; i++)
            {
                JsonData item = jsonData[i];
                JsonData itemName = item["name"];
                JsonData itemStage = item["stage"];
                JsonData itemClearTime = item["clearTime"];
                string name = itemName.ToString();
                string stage = itemStage.ToString();
                string clearTime = itemClearTime.ToString();

                GameObject obj = (GameObject)Instantiate(m_rankPrefab, Vector3.zero, Quaternion.identity);
                obj.transform.SetParent(m_contentRoot);

                Rank script = obj.GetComponent<Rank>();
                script.Setup(Convert.ToString(i)+"\t" + name +"\t"+ stage +"\t\t"+ clearTime);
                /*
                Debug.Log(name);
                Debug.Log(stage);
                Debug.Log(clearTime);
                */
            }

        }
    }

    


    

}
