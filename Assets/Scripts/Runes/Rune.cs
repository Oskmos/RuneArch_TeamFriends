using UnityEngine;
using UnityEngine.UI;

namespace Runes
{
    public class Rune : MonoBehaviour{
        [SerializeField] RuneData runeData;
        Image _runeSprite;
        [SerializeField] Text amountText;

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
            amountText.text = runeData.amount.ToString();
        }
    }
}