using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMode : MonoBehaviour
{
    public string mode;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = this.transform.GetComponent<Button>();
        button.onClick.AddListener(SetStage);
    }

    // Update is called once per frame
    public void SetStage()
    {        
        StageManager.mode = mode;
    }
}
