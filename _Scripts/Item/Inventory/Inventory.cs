using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

namespace Items.Inventory {
    /******************************************************************************************
     The inventory is a list of scriptable item objects that we maintain a list of.
     The usable items can be transfered to the players hotbar and used to attack and what not.
     But we don't worry about that here cause as far as we know the items are just scriptable objects.
    *******************************************************************************************/
    public class Inventory : MonoBehaviour {
        [SerializeField] private int inventorySize;
        [SerializeField] private Dictionary<ItemScriptableObject, int> itemDictionary;
        [SerializeField] private List<ItemScriptableObject> inventoryVisual;

        public delegate void InventoryChangedDelegate();
        public InventoryChangedDelegate ourInventoryChanged;

        private void Start() {
            inventoryVisual = new List<ItemScriptableObject>();
            itemDictionary = new Dictionary<ItemScriptableObject, int>();
        }

        public bool addItemToInventory(ItemScriptableObject item, int amount) {
            if (amount > 0) {
                if (itemDictionary.Count < inventorySize) {
                    if (itemDictionary.ContainsKey(item)) {
                        itemDictionary[item] += amount;
                        ourInventoryChanged();
                        return true;
                    } else {
                        inventoryVisual.Add(item);
                        itemDictionary.Add(item, amount);
                        ourInventoryChanged();
                        return true;
                    }

                }
            } else {
                Debug.Log("Trying to add an item of amount " + amount.ToString());
            }
            return false;
        }

        public bool removeItemsFromInventory(ItemScriptableObject item, int amount) {
            Debug.Log("Looking for " + item.itemName + " in the dictionary");
            if (itemDictionary.ContainsKey(item)) {
                Debug.Log("Found the item in the dictionary removing " + amount);
                itemDictionary[item] -= amount;
                if (itemDictionary[item] <= 0) {
                    itemDictionary.Remove(item);
                    inventoryVisual.Remove(item);
                    ourInventoryChanged();
                }
                return true;
            }
            return false;
        }

        public List<ItemScriptableObject> getAllItems() {
            return new List<ItemScriptableObject>(itemDictionary.Keys);
        }

        public int getItemAmount(ItemScriptableObject item) {
            return itemDictionary[item];
        }

        public List<int> getItemAmounts() {
            return new List<int>(itemDictionary.Values);
        }
    }
}