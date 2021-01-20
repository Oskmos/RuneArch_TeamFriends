using System.Collections;
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
        public UnityEvent<RuneData> onAdd; 
        public RuneRarity[] rarities;

        private void Awake()
        {
            SortByRarity();
        }

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
            onAdd?.Invoke(runeData); 
            SortByRarity();
            onChange?.Invoke(this);
            return true;
        }
        public virtual void RemoveRune(RuneData runeData)
        {
            //TODO: Try to return runeData
            RuneData rune = GetRune(runeData);
            if (rune != null)
            {
                rune.amount -= runeData.amount;
                if(rune.amount == 0)
                    runes.Remove(rune);
            }
            SortByRarity();
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

        public virtual void Clear()
        {
            runes = new List<RuneData>();
            onChange.Invoke(this);
        }
        public void SortByRarity()
        {
            List<RuneData> newRunes = new List<RuneData>();
            for (int i = rarities.Length-1; i >= 0; i--)
            {
                foreach (var rune in runes)
                {
                    if (rune.runeRarity == rarities[i])
                    {
                        newRunes.Add(rune);
                    }
                }
            }
            runes = newRunes;
        }
    }
}