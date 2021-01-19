using Runes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveToMerger : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {
    GameObject _selectedRune;
    InventoryData _inventoryData;
    public void OnBeginDrag(PointerEventData eventData) {
        _selectedRune = eventData.hovered.Find(x => x.GetComponent<Rune>());
        if (_selectedRune == null) return;
        _inventoryData = eventData.hovered.Find(x => x.GetComponent<InventoryData>()).GetComponent<InventoryData>();
        _selectedRune = Instantiate(_selectedRune.gameObject, transform);
        _selectedRune.GetComponent<Image>().raycastTarget = false;

        RuneData currentRuneData = _selectedRune.GetComponent<Rune>().RuneData;
        
        currentRuneData.amount = 1;
        
        _selectedRune.GetComponent<Rune>().RefreshVisuals();
        
        _inventoryData.RemoveRune(currentRuneData);
        
        //TODO: Set alpha to 0.4f and also make the rune move with mouse
    }

    public void OnEndDrag(PointerEventData eventData) {
        // foreach (var item in eventData.hovered) {
        //     Debug.Log($"{item.name}");
        // }
        
        var currentInventory = eventData.hovered.Find(x => x.GetComponent<InventoryData>());
        //Debug.Log(currentInventory.name);
        if (currentInventory == null) {
            _inventoryData.AddRune(_selectedRune.GetComponent<Rune>().RuneData);
        }
        else {
            currentInventory.GetComponent<InventoryData>().AddRune(_selectedRune.GetComponent<Rune>().RuneData);    
        }
        Destroy(_selectedRune);
    }

    public void OnDrag(PointerEventData eventData) {
        if (_selectedRune == null) return;
        _selectedRune.transform.position = eventData.position;
    }
}
