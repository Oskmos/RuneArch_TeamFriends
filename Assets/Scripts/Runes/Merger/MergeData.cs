namespace Runes.Merger {
    public class MergeData : InventoryData {
        RuneRarity _currentRuneRarity;
        const string ForbiddenRarity = "Legendary";

        public override void AddRune(RuneData runeData) {
            if (runeData.runeRarity.name == ForbiddenRarity) return;
            if (runeData.runeRarity != _currentRuneRarity && _currentRuneRarity != null) return;
            base.AddRune(runeData);
            _currentRuneRarity = runeData.runeRarity;
        }

        public override void RemoveRune(RuneData runeData) {
            base.RemoveRune(runeData);
            if (runes.Count == 0) {
                _currentRuneRarity = null;
            }
        }
    }
}