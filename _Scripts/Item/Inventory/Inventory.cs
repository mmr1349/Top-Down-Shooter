using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

namespace Items.Inventory {
    public class Inventory : MonoBehaviour {
        [SerializeField] private int inventorySize;
        [SerializeField] private List<Item> inventoryItems;

        public bool addItemToInventory(Item item) {
            if (inventoryItems.Count < inventorySize) {
                inventoryItems.Add(item);
                return true;
            }
            return false;
        }

        public bool removeItemFromInventory(Item item) {
            return inventoryItems.Remove(item);
        }

        public List<Item> getAllItems() {
            return inventoryItems;
        }
    }
}