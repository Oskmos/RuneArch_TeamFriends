using System;
using UnityEngine;

namespace Runes.Inventory
{
    public class Inventory : MonoBehaviour
    {
        public Rune[] runes;
        InventoryData inventoryData;
        private void Awake()
        {
            inventoryData = GetComponent<InventoryData>();
        }

        private void Start()
        {
            inventoryData.onChange.AddListener(delegate { UpdateInventory(); });
            UpdateInventory();
        }

        public void UpdateInventory()
        {
            for (int i = 0; i < runes.Length; i++)
            {
                runes[i].gameObject.SetActive(false);
                if (i < inventoryData.runes.Count)
                {
                    runes[i].RuneData = inventoryData.runes[i];
                    runes[i].gameObject.SetActive(true);
                }
            }
        }
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