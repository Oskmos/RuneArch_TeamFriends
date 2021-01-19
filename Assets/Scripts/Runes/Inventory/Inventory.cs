using System;
using UnityEngine;

namespace Runes.Inventory
{
    public class Inventory : MonoBehaviour
    {
        public InventoryData data;

            // void Start() {
            //     for (var i = 0; i < data.runes.Count; i++) {
            //         transform.GetChild(i).GetChild(0).GetComponent<Rune>().RuneData = data.runes[i];
            //     }
            // }
            //
            // void Update() {
            //     if (Input.GetKeyDown(KeyCode.K)) {
            //         transform.GetChild(0).GetChild(0).GetComponent<Rune>().RuneData = data.runes[2];
            //     }
            // }
    }
}