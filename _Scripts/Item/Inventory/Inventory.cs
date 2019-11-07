using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

namespace Items.Inventory {
    public class Inventory : MonoBehaviour {
        [SerializeField] private int inventorySize;
        [SerializeField] private Dictionary<ItemScriptableObject, int> inventory;

        public bool addItemToInventory(ItemScriptableObject item, int amount) {
            if (inventory.Count < inventorySize) {
                if (inventory.ContainsKey(item)) {
                    inventory[item] += amount;
                    return true;
                }
            }
            return false;
        }

        public bool removeItemsFromInventory(ItemScriptableObject item, int amount) {
            if (inventory.ContainsKey(item)) {
                inventory[item] -= amount;
                if (inventory[item] <= 0) {
                    inventory.Remove(item);
                }
                return true;
            }
            return false;
        }

        public List<ItemScriptableObject> getAllItems() {
            return new List<ItemScriptableObject>(inventory.Keys);
        }
    }
}