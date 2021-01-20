namespace Runes.Merger {
    public class MergeData : InventoryData {
        RuneRarity _currentRuneRarity;
        const string ForbiddenRarity = "Legendary";
        public int maxAmount;
        public RuneRarity CurrentRuneRarity { get => _currentRuneRarity; }

        public override bool AddRune(RuneData runeData) {
            if (runeData.runeRarity.name == ForbiddenRarity) return false;
            if (runeData.runeRarity != _currentRuneRarity && _currentRuneRarity != null) return false;
            if (CurrentAmount() + runeData.amount > maxAmount) return false;
            base.AddRune(runeData);
            _currentRuneRarity = runeData.runeRarity;
            return true;
        }

        public override void RemoveRune(RuneData runeData) {
            base.RemoveRune(runeData);
            if (runes.Count == 0) {
                _currentRuneRarity = null;
            }
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
    }
}