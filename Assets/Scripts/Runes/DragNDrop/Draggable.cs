using UnityEngine;
using UnityEngine.EventSystems;

namespace Runes.DragNDrop {
    public class Draggable : MonoBehaviour, IPointerClickHandler, IDragHandler, IPointerUpHandler {
        bool _shouldDrag;
    
        public void OnPointerClick(PointerEventData eventData) {
            _shouldDrag = !_shouldDrag;
        }
    
        public void OnDrag(PointerEventData eventData) {
            GetComponent<RectTransform>().position = eventData.position;
        }


        public void OnPointerUp(PointerEventData eventData) {
            
        }
    }
}