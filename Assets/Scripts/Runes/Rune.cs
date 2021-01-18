using UnityEngine;
using UnityEngine.UI;

namespace Runes
{
    public class Rune : MonoBehaviour{
        [SerializeField] RuneData runeData;
        Image _runeSprite;
        
         public RuneData RuneData {
            get => runeData;
            set {
                runeData = value;
                RefreshVisuals(); 
            }
        }
        
        void Awake() {
            _runeSprite = GetComponent<Image>();
            RefreshVisuals();
        }

        void RefreshVisuals() {
            _runeSprite.sprite = runeData.runeType.Icon;
            _runeSprite.color = runeData.runeRarity.RarityColor;
        }
    }
}