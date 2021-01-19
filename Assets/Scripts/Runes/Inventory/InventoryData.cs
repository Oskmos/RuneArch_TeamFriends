﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Runes
{
    [System.Serializable]
    public class InventoryData : MonoBehaviour
    {
        public List<RuneData> runes = new List<RuneData>();
        public UnityEvent<InventoryData> onChange;

        public RuneRarity tempRarity;
        public RuneType tempType;

        public virtual bool AddRune(RuneData runeData)
        {
            RuneData rune = GetRune(runeData);
            if(rune == null)
            {
                runes.Add(new RuneData(runeData));
            }
            else
            {
                rune.CombineWith(runeData);
            }
            onChange.Invoke(this);
            return true;
        }
        public virtual void RemoveRune(RuneData runeData)
        {
            RuneData rune = GetRune(runeData);
            if (rune != null)
            {
                rune.amount -= runeData.amount;
                if(rune.amount == 0)
                    runes.Remove(rune);
            }
            onChange.Invoke(this);
        }

        public bool ContainsRune(RuneData runeData)
        {
            return GetRune(runeData) != null;
        }

        public RuneData GetRune(RuneData runeData)
        {
            foreach (var rune in runes)
            {
                if (rune.runeRarity == runeData.runeRarity && rune.runeType == runeData.runeType)
                {
                    return rune;
                }
            }
            return null;
        }

        [ContextMenu("AddaRuneTillFacebook")]
        public void AddaRuneTillFacebook()
        {
            AddRune(new RuneData(tempType, tempRarity, 1));
        }

        [ContextMenu("HataRune")]
        public void HataRune()
        {
            RemoveRune(new RuneData(tempType, tempRarity, 1));
        }
    }
}