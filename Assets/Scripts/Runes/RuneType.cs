using UnityEngine;

namespace Runes {
    [CreateAssetMenu(menuName = "RuneData/Rune Type")]
    public class RuneType : ScriptableObject {
        [SerializeField] Sprite icon;
        public Sprite Icon => icon;
    }
}