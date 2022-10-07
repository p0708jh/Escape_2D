using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPScript : MonoBehaviour
{
    public void Reward()
    {
        print("결제 성공");
    }

    public void Failed()
    {
        print("결제실패");
    }
}
