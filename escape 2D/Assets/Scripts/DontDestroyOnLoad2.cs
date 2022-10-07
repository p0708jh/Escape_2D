using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad2 : MonoBehaviour
{
    private void Awake()
    {

        var obj = FindObjectsOfType<DontDestroyOnLoad2>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
