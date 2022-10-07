using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActive : MonoBehaviour
{
    public GameObject deActive;
    public GameObject deActive2;
    public GameObject deActive3;
    public GameObject deActive4;
    public GameObject deActive5;
    public GameObject deActive6;
    public GameObject active;
    public GameObject active2;
    public GameObject active3;
    public GameObject active4;
    public GameObject active5;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = this.transform.GetComponent<Button>();
        button.onClick.AddListener(Set);
    }

    void Set()
    {
        deActive.SetActive(false);
        deActive2.SetActive(false);
        deActive3.SetActive(false);
        deActive4.SetActive(false);
        deActive5.SetActive(false);
        deActive6.SetActive(false);
        active.SetActive(true);
        active2.SetActive(true);
        active3.SetActive(true);
        active4.SetActive(true);
        active5.SetActive(true);
    }
}
