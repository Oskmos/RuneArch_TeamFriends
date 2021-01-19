﻿using UnityEngine;

namespace Runes.Merger {
    public class MergeController : MonoBehaviour {
        MergeData _mergeData = new MergeData();
        
        public void Merge() {
            if (_mergeData.runes.Count < 2) return;
            var chanceToUpgrade = 1f;
            if (_mergeData.runes.Count == 2) {
                chanceToUpgrade *= 0.8f;
                   
            }
        }
    }
}