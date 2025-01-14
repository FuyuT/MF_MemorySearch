using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MemoryUI : MonoBehaviour
{
    /*******************************
    * protected
    *******************************/
    [SerializeField] protected MemorySelectManager.MoveType moveType;

    [SerializeField] protected MemoryType memoryType;

    /*******************************
    * public
    *******************************/

    //透明化
    public void Transparent()
    {
        Color beforeColor = gameObject.GetComponent<Image>().color;
        gameObject.GetComponent<Image>().color = new Color(beforeColor.r, beforeColor.g, beforeColor.b,0);
    }

    //非透明化
    public void Opaque()
    {
        Color beforeColor = gameObject.GetComponent<Image>().color;
        gameObject.GetComponent<Image>().color = new Color(beforeColor.r, beforeColor.g, beforeColor.b, 255);
    }

    //getter

    public MemorySelectManager.MoveType GetMoveType()
    {
        return moveType;
    }

    public bool IsTypeNone()
    {
        return memoryType == MemoryType.None ? true : false;
    }

    public MemoryType GetMemoryType()
    {
        return memoryType;
    }

    //setter
    public void ChangeMemoryType(MemoryType type)
    {
        memoryType = type;
        //画像を変更
        GetComponent<Image>().sprite = DataManager.instance.GetMemorySprite(memoryType);
    }

}
