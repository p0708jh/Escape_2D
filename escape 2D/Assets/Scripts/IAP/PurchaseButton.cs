using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    public GameObject m_loadingPrefab;
    public string targetProductId;

    public void HandleClick()
    {
        /* non conum일때 구현할것   
           if(targetProductId == IAPManager.ProductSkin || targetProductId == IAPManager.ProductSubscription)
           {
             if(IAPManager.Instance.HadPurchased(targetProductId))
            {
                Debug.Log("이미 구매한 상품");
            }
        }

           */
        Destroy(GameObject.Find("Purchase(Clone)"));

        Transform m_contentRoot = GameObject.Find("UiCanvas").transform;
        GameObject obj = (GameObject)Instantiate(m_loadingPrefab, Vector3.zero, Quaternion.identity);

        obj.transform.SetParent(m_contentRoot);
        obj.transform.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        obj.transform.localPosition = new Vector3(0, 0, 0);
        IAPManager.Instance.RestorePurchase();

        //IAPManager.Instance.HadPurchased("asdfasdf");

        IAPManager.Instance.Purchase(targetProductId);

        
    }
}
