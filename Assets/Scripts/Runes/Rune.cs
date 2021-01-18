using System;
using UnityEngine;
using UnityEngine.UI;

namespace Runes
{
    public class Rune : MonoBehaviour{
        public RuneData runeData;

        Image _runeSprite;
        
        void Awake() {
            _runeSprite = GetComponent<Image>();
            _runeSprite.sprite = runeData.runeType.Icon;
            _runeSprite.color = runeData.runeRarity.RarityColor;
        }
    }
}