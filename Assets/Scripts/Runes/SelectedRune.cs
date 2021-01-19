using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Runes {
    [Serializable]
    public class RuneEvent : UnityEvent<RuneData> {}
    public class SelectedRune : MonoBehaviour, IPointerClickHandler {
        [SerializeField] RuneEvent runeEvent;
        RuneData _data;
        
        void Awake() {
             _data = GetComponent<RuneData>();
        }

        public void OnPointerClick(PointerEventData eventData) {
            runeEvent?.Invoke(_data);
        }
    }
}