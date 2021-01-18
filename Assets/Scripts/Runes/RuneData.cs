using System;

namespace Runes {
    [Serializable]
    public class RuneData {
        public RuneType runeType;
        public RuneRarity runeRarity;
        public int amount;

        public RuneData(RuneData runeData)
        {
            runeType = runeData.runeType;
            runeRarity = runeData.runeRarity;
        }

        public void CombineWith(RuneData runeData)
        {
            amount += runeData.amount;
            runeData.amount -= runeData.amount;
        }
    }
}