using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Runes{
    
    public class MoveToTargetInventory : MonoBehaviour, IPointerClickHandler{
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

        public void OnPointerClick(PointerEventData eventData){
            var selectedRune = eventData.hovered.Find(x => x.GetComponent<Rune>());
            if(selectedRune == null)
                return;
            var runeData = new RuneData(selectedRune.GetComponent<Rune>().RuneData);
            runeData.amount = 1;
            moveToInventoryData.AddRune(runeData);
            inventoryData.RemoveRune(runeData);
        }
    }
}