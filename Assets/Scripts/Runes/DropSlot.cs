using UnityEngine;
using UnityEngine.EventSystems;

namespace Runes{
    public class DropSlot : MonoBehaviour, IDropHandler, IPointerClickHandler
    {
        //TODO: Polish feature remove other rarities when adding a new one
        
        public void OnDrop(PointerEventData eventData){
            if (eventData.pointerDrag == null) return;
            RemoveOldRune();
            //TODO: Check if empty
            eventData.pointerDrag.GetComponent<SelectedRune>().rectTransform.SetParent(transform);
            eventData.pointerDrag.GetComponent<SelectedRune>().rectTransform.anchoredPosition = Vector2.zero;
            //TODO:Send data to merge inventory
        }

        public void OnPointerClick(PointerEventData eventData){
            RemoveOldRune();
        }

        void RemoveOldRune(){
            if(transform.childCount == 0)
                return;
            Destroy(transform.GetChild(0).gameObject);
            
            //TODO: Send data to inventory and merge inventory
        }
    }
}
