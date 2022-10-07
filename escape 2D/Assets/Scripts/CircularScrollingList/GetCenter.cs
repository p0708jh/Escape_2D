using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GetCenter : MonoBehaviour
{
    public ListPositionCtrl list;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    

    public void Update()
    {
        int contentID = list.GetCenteredContentID();
        string centeredContent = list.listBank.GetListContent(contentID);

        transform.GetChild(Convert.ToInt32(centeredContent)-1).GetComponent<Image>().enabled = false;
        transform.GetChild(Convert.ToInt32(centeredContent)-1).GetChild(0).gameObject.SetActive(true);

        foreach (Transform child in transform)
        {
            if (child.name != "Chapter" + centeredContent)
            {
                child.GetChild(0).gameObject.SetActive(false);
                child.GetComponent<Image>().enabled = true;
            }

        }


        //Debug.Log(transform.GetChild(Convert.ToInt32(centeredContent) - 1).name);
    }


}
