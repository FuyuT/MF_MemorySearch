﻿using UnityEngine;

public class InventoryEquipmentUI : EquipmentUI
{
    /*******************************
    * private
    *******************************/

    [SerializeField] EquipmentUI gameEquipmentUI;

    private void Update()
    {
        //装備の変更があるか確認する
        int no = 0;
        if(IsChangeMemory(ref no))
        {
            //装備が変わっていれば、データに反映
            DataManager.instance.IPlayerData().SetEquipmentMemory(no, MemoriesUI[no].GetMemoryType());
            //ゲーム画面の装備UIを変更
            gameEquipmentUI.SetEquipmentMemoriesUI();
        }
    }

    //装備が変わっているか確認する
    bool IsChangeMemory(ref int no)
    {
        for (int n = 0; n < MemoriesUI.Length; n++)
        {
            if (DataManager.instance.IPlayerData().GetEquipmentMemory(n) != MemoriesUI[n].GetMemoryType())
            {
                no = n;
                return true;
            }
        }
        return false;
    }

    private void OnEnable()
    {
        //Activeになった時に、装備しているメモリをUIに反映させる
        SetEquipmentMemoriesUI();
    }
}