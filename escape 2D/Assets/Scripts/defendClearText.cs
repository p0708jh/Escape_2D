using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defendClearText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("UiCanvas").transform.GetChild(3).gameObject.SetActive(false); // Stage Clear Text
        GameObject.Find("UI").transform.GetChild(2).gameObject.SetActive(false); // NEXT
        GameObject.Find("UI").transform.GetChild(6).gameObject.SetActive(false); // Donation
    }

}
