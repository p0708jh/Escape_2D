using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{
    public Text m_text;

    public void Setup(string txt) {
        m_text.text = txt;
    }
    
}
