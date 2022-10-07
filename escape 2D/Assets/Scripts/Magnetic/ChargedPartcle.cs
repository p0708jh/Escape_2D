using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedPartcle : MonoBehaviour
{
    public float charge = 0;

    private void Start()
    {
        UpdateColor();
    }

    public void UpdateColor()
    {
        
            Color color = charge > 0 ? Color.blue : Color.red;
            GetComponent<Renderer>().material.color = color;
        
    }
}
