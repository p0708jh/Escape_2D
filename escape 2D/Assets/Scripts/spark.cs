using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spark : MonoBehaviour
{
    public float startTime;
    public float T;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spark());
    }

    IEnumerator Spark()
    {
        yield return new WaitForSeconds(startTime);
        while (true)
        {           
            if (transform.GetChild(0).gameObject.activeSelf == true)
            {
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
            else
            {
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(true);
                }
            }
            yield return new WaitForSeconds(T);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

}
