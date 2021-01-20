using System;
using System.Collections.Generic;
using UnityEngine;

namespace Runes{
    
    public class MoveToTargetInventory : MonoBehaviour{
        [SerializeField]InventoryData moveToInventoryData;
        InventoryData inventoryData;
        List<RuneData> runeDataList = new List<RuneData>();

        void Start(){
            inventoryData = GetComponent<InventoryData>();
        }
        public void Move(){
            if(inventoryData.runes.Count == 0)
                return;
            foreach (var runeData in inventoryData.runes){
                if(moveToInventoryData.AddRune(runeData))
                    runeDataList.Add(runeData);
            }
            ClearData();
        }
        void ClearData(){
            if(runeDataList.Count == 0)
                return;
            foreach (var runeData in runeDataList){
                inventoryData.RemoveRune(runeData);
            }
            runeDataList.Clear();
        }
    }
}