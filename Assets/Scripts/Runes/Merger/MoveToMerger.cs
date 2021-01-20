using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Runes.Merger {
    public class MoveToMerger : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {
        GameObject _selectedRune;
        InventoryData _inventoryData;
        
        bool SpawnRuneVisual(PointerEventData eventData) {
            if (_selectedRune == null) return true;
            _inventoryData = eventData.hovered.Find(x => x.GetComponent<InventoryData>()).GetComponent<InventoryData>();
            _selectedRune = Instantiate(_selectedRune.gameObject, transform);
            _selectedRune.GetComponent<Image>().raycastTarget = false;
            return false;
        }
        
        void InventoryHandler(GameObject currentInventory) {
            if (currentInventory == null || !currentInventory.GetComponent<InventoryData>()
                .AddRune(_selectedRune.GetComponent<Rune>().RuneData)) {
                _inventoryData.AddRune(_selectedRune.GetComponent<Rune>().RuneData);
            }
            Destroy(_selectedRune);
        }
        
        //Spawns a Rune visual and removes 1 count of said rune from inventory.
        public void OnBeginDrag(PointerEventData eventData) {
            _selectedRune = eventData.hovered.Find(x => x.GetComponent<Rune>());
            if (SpawnRuneVisual(eventData)) return;

            RuneData currentRuneData = _selectedRune.GetComponent<Rune>().RuneData;
            currentRuneData.amount = 1;
            _selectedRune.GetComponent<Rune>().RefreshVisuals();
            _inventoryData.RemoveRune(currentRuneData);
        }
        
        //Handles Inventory add / remove from our inventory and merger inventory.
        public void OnEndDrag(PointerEventData eventData) {
            if (_selectedRune == null) return;
            var currentInventory = eventData.hovered.Find(x => x.GetComponent<InventoryData>());            
            InventoryHandler(currentInventory);
        }
        
        //Moves the rune visual with our mouse as we drag.
        public void OnDrag(PointerEventData eventData) {
            if (_selectedRune == null) return;
            _selectedRune.transform.position = eventData.position;
        }
    }
}
