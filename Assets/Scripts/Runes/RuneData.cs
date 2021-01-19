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
            amount = runeData.amount;
        }
        public RuneData(RuneType runeType, RuneRarity runeRarity, int amount)
        {
            this.runeType = runeType;
            this.runeRarity = runeRarity;
            this.amount = amount;
        }

        public void CombineWith(RuneData runeData)
        {
            amount += runeData.amount;
            runeData.amount -= runeData.amount;
        }
    }
}