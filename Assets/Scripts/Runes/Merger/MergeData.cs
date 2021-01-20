using UnityEngine;

namespace Runes.Merger {
    public class MergeData : InventoryData {
        [SerializeField] RuneRarity forbiddenRarity;
        public int maxAmount;
        public RuneRarity CurrentRuneRarity => runes.Count > 0? runes[0].runeRarity : null;

        public override bool AddRune(RuneData runeData) {
            //if (runeData.runeRarity == forbiddenRarity) return false;
            //if (runeData.runeRarity != _currentRuneRarity && _currentRuneRarity != null) return false;
            base.AddRune(runeData);
            return true;
        }

        public override void RemoveRune(RuneData runeData) {
            base.RemoveRune(runeData);
        }

        public int CurrentAmount()
        {
            int returnedInt = 0;
            foreach (var rune in runes)
            {
                returnedInt += rune.amount;
            }
            return returnedInt;
        }

        public override void Clear()
        {
            base.Clear();
        }
    }
}