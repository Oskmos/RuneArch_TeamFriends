using System;
using UnityEngine;
using UnityEngine.Events;

namespace Runes.Merger{
    public class MergeRarityCheck : MonoBehaviour{

        [SerializeField]MergeData mergeData;
        [SerializeField]InventoryData inventoryData;
        [SerializeField]UnityEvent moveRuneDataEvent;
        [SerializeField] RuneRarity forbiddenRarity;

        void Start(){
            mergeData.onAdd.AddListener(Check);
        }

        void Check(RuneData runeData){
            if (runeData.runeRarity == forbiddenRarity){
                mergeData.RemoveRune(runeData);
                inventoryData.AddRune(runeData);
            } else if(runeData.runeRarity != mergeData.CurrentRuneRarity){
                ExchangeRunes();
            }
            if (mergeData.CurrentAmount() > mergeData.maxAmount){
                inventoryData.AddRune(runeData);
                mergeData.RemoveRune(runeData);
            }
        }

        void ExchangeRunes(){
            while (mergeData.runes.Count > 1){
                inventoryData.AddRune(mergeData.runes[0]);
                mergeData.RemoveRune(mergeData.runes[0]);
            }
        }

    }
}