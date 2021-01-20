using System;
using UnityEngine;
using UnityEngine.Events;

namespace Runes.Merger{
    public class MergeRarityCheck : MonoBehaviour{

        [SerializeField]MergeData mergeData;
        [SerializeField]InventoryData inventoryData;
        [SerializeField]UnityEvent moveRuneDataEvent;
        [SerializeField] RuneRarity forbiddenRarity;
        //TODO: Merge data list
        void Start(){
            mergeData.onAdd.AddListener(Check);
        }

        void Check(RuneData runeData){
            if (runeData.runeRarity == forbiddenRarity){
                mergeData.RemoveRune(runeData);
                inventoryData.AddRune(runeData);
            }
            if(mergeData.CurrentRuneRarity == runeData.runeRarity)
                return;
            //moveRuneDataEvent?.Invoke();
            mergeData.AddRune(runeData);
        }

    }
}