using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLogo : MonoBehaviour
{
    Button button;
    public GameObject m_object;
    public Sprite changeImage;
    public float width;
    public float height;
    // Start is called before the first frame update
    void Start()
    {
        button = this.transform.GetComponent<Button>();
        button.onClick.AddListener(Set);
    }

    private void Set()
    {
        m_object.GetComponent<Image>().sprite = changeImage; // Back button
        m_object.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,width);
        m_object.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
    }
}
