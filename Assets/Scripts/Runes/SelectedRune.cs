using System;
using Controllers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Runes {
    public class SelectedRune : MonoBehaviour, IPointerClickHandler {
        public RuneMover runeMover;

        public void OnPointerClick(PointerEventData eventData) {
            runeMover.MoveToMerger(gameObject);
        }
    }
}