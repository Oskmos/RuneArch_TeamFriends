using UnityEngine;
using UnityEngine.EventSystems;

namespace Runes.DragNDrop {
    public class Draggable : MonoBehaviour, IPointerClickHandler, IPointerUpHandler {
        bool _shouldMove;
        
        public void OnPointerClick(PointerEventData eventData) {
            
        }
        
        public void OnPointerUp(PointerEventData eventData) {
            
        }
    }
}