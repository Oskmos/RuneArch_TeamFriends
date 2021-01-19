using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runes.Merger {
    public class MergeController : MonoBehaviour {
        MergeData _mergeData;

        void Awake() {
            _mergeData = GetComponent<MergeData>();
        }

        //TODO: ADD CHANCES and add rune to inventory
        
        public void Merge() {
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
            if (roll <= chanceToUpgrade) {
                //TODO: Add upgraded to Merge complete slot
            }
            //TODO: Clear merge
        }
    }
}