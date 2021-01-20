using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runes.Merger {
    public class MergeController : MonoBehaviour {
        MergeData _mergeData;
        public MergeData resultData;

        [SerializeField] RuneRarity[] rarities;

        void Awake() {
            _mergeData = GetComponent<MergeData>();
        }

        //TODO: ADD CHANCES and add rune to inventory
        
        public void Merge()
        {
            if (resultData.CurrentAmount() > 0)
            {
                return;
            }
            if (_mergeData.CurrentAmount() < 2) return;
            var chanceToUpgrade = 0;
            if (_mergeData.CurrentAmount() == 2) {
                chanceToUpgrade = 20;
            }
            else if (_mergeData.CurrentAmount() == 3) {
                chanceToUpgrade = 55;
            }
            else if (_mergeData.CurrentAmount() == 4) {
                chanceToUpgrade = 95;
            }

            var roll = Random.Range(1, 101);

            RuneRarity runeRarity = _mergeData.CurrentRuneRarity;

            if (roll <= chanceToUpgrade)
            {
                runeRarity = GetUpgradedRarity(runeRarity);
            }

            int typeIndex = Random.Range(0, _mergeData.runes.Count);
            //TODO: Add upgraded to Merge complete slot
            resultData.AddRune(new RuneData(_mergeData.runes[typeIndex].runeType, runeRarity, 1));

            _mergeData.Clear();


            //resultData.Clear();
            //TODO: Clear merge
        }

        RuneRarity GetUpgradedRarity(RuneRarity runeRarity)
        {
            for (int i = 0; i < rarities.Length; i++)
            {
                if(runeRarity == rarities[i])
                {
                    return rarities[i + 1];
                }
            }
            throw new Exception("Error, Couldn't Find runeRarity for merge controller");
        }
    }
}