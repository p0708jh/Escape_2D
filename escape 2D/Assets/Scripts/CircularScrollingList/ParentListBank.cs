using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentListBank : BaseListBank
{
    //Chapter의 수
    private int[] _contents = {
            1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21
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
