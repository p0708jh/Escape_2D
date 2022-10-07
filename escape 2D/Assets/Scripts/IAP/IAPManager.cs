using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour, IStoreListener
{
    public const string ProductDonation = "coffee"; // Consumable


    private const string _iOS_DonationId = "com.company.escape2d.coffeedonation";
    private const string _android_DonationId = "com.company.escape2d.coffeedonation";

    private static IAPManager m_instance;

    public static IAPManager Instance
    {
        get 
        {
            if (m_instance != null) return m_instance;
            m_instance = FindObjectOfType<IAPManager>();
            if (m_instance == null) m_instance = new GameObject().AddComponent<IAPManager>();
            return m_instance;
        }
    }

    private IStoreController storeController; // 구매 과정을 제어하는 함수 제공
    private IExtensionProvider storeExtensionProvider; // 여러 플랫폼을 위한 확장 처리를 제공

    public bool IsInitialized => storeController != null && storeExtensionProvider != null;

        /* 위에 식과 완전 똑같은 내용
    {
        get
        {
            if (storeController != null && storeExtensionProvider != null)
            {
                return true;
            }
            return false;
        }
    }
        */
    void Awake()
    {
        if (m_instance != null && m_instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        InitUnityIAP();   
    }

    void InitUnityIAP()
    {
        if (IsInitialized) return;

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(
            ProductDonation, ProductType.Consumable, new IDs(){
                    { _iOS_DonationId,AppleAppStore.Name},
                    { _android_DonationId,GooglePlay.Name}
                }
        );

        UnityPurchasing.Initialize(this, builder);
    }

    public void OnInitialized(IStoreController controller,IExtensionProvider extensions)
    {
        Debug.Log("IAP 초기화 성공");
        storeController = controller;
        storeExtensionProvider = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.LogError($"IAP 초기화 실패{error}");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        Debug.Log($"구매 성공 - ID: {args.purchasedProduct.definition.id}");

        if (args.purchasedProduct.definition.id == ProductDonation)
        {
            Debug.Log("커피기부 완료!");
        }

        Destroy(GameObject.Find("Purchase(Clone)"));
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reson)
    {
        Destroy(GameObject.Find("Purchase(Clone)"));
        Debug.LogWarning($"구매 실패 - {product.definition.id}, {reson}");
    }

    public void Purchase(string productId)
    {
        if (!IsInitialized) return;

        var product = storeController.products.WithID(productId);

        if (product != null && product.availableToPurchase)
        {
            Debug.Log($"구매 시도 - {product.definition.id}");
            storeController.InitiatePurchase(product);
        }
        else
        {
            Destroy(GameObject.Find("Purchase(Clone)"));
            Debug.Log($"구매 시도 불가 - {productId}");
        }
    }

    // Apple은 무조건 이게 있어야함
    public void RestorePurchase()
    {
        if (!IsInitialized) return;

        if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("구매 복구 시도");

            var appleExt = storeExtensionProvider.GetExtension<IAppleExtensions>();

            appleExt.RestoreTransactions(
                result => Debug.Log($"구매 복구 시도 결과 - {result}"));
        }
    }

    // 소모용아닌것들 

    public bool HadPurchased(string productId)
    {
        if (!IsInitialized) return false;

        var product = storeController.products.WithID(productId);

        if (product != null)
        {
            return product.hasReceipt;
        }
        return false;
    }
}
