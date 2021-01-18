﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runes
{
    [System.Serializable]
    public class InventoryData
    {
        public List<RuneData> runes = new List<RuneData>();

        public void AddRune(RuneData runeData)
        {
            RuneData rune = GetRune(runeData);
            if(rune == null)
            {
                runes.Add(new RuneData(rune));
            }
            else
            {

            }
        }
        public void RemoveRune(RuneData runeData)
        {
            RuneData rune = GetRune(runeData);
            if (rune != null)
            {
                runes.Remove(rune);
            }
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
    }
}