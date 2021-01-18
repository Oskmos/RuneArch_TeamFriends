using UnityEngine;

namespace Runes {
    [CreateAssetMenu(menuName = "RuneData/Rune Rarity")]
    public class RuneRarity : ScriptableObject {
        [SerializeField] Color rarityColor;
        public Color RarityColor  => rarityColor;
    }
}