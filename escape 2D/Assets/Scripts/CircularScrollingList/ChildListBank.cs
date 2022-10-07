using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildListBank : BaseListBank
{
    // 각Chapter의 스테이지 수
    private int[] _contents = {
        1, 2, 3
    };

    public override string GetListContent(int index)
    {
        return _contents[index].ToString();
    }

    public override int GetListLength()
    {
        return _contents.Length;
    }
    
    public void GetSelectedContentID(int contentID)
    {
        Debug.Log("Selected content ID: " + contentID.ToString() +
            ", Content: " + GetListContent(contentID));
    }
    
}