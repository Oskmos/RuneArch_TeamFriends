using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Runes {
    [Serializable]
    public class RuneEvent : UnityEvent<RuneData> {}
    public class SelectedRune : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {
        [SerializeField]RuneEvent runeEvent;
        [SerializeField]Canvas canvas;
        [SerializeField]Rune runePrefab;
        RuneData runeData;
        CanvasGroup canvasGroup;
        [HideInInspector]public RectTransform rectTransform;

        void Awake(){
            runeData = GetComponent<Rune>().RuneData;
            
        }
        public void OnPointerDown(PointerEventData eventData){
        }
        public void OnBeginDrag(PointerEventData eventData){
            var instance = Instantiate(runePrefab, transform.position, Quaternion.identity, canvas.transform);
            instance.RuneData = runeData;
            canvasGroup = instance.GetComponent<CanvasGroup>();
            rectTransform = instance.GetComponent<RectTransform>();
            canvasGroup.blocksRaycasts = false;
            //Remove one count and the new one only have one.
        }
        public void OnEndDrag(PointerEventData eventData){
            //runeEvent?.Invoke(_data);
            
        }

        public void OnDrag(PointerEventData eventData){
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }
}