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
        [SerializeField] private Dictionary<string, ItemScriptableObject> itemDictionary;


        public bool addItemToInventory(ItemScriptableObject item) {
            if (itemDictionary.Count < inventorySize) {
                if (itemDictionary.ContainsKey(item.name)) {
                    itemDictionary[item.name].amount += item.amount;
                    return true;
                } else {
                    itemDictionary.Add(item.name, item);
                    return true;
                }
                
            }
            return false;
        }

        public bool removeItemsFromInventory(ItemScriptableObject item, int amount) {
            if (itemDictionary.ContainsKey(item.name)) {
                itemDictionary[item.name].amount -= amount;
                if (itemDictionary[item.name].amount <= 0) {
                    itemDictionary.Remove(item.name);
                }
                return true;
            }
            return false;
        }

        public List<ItemScriptableObject> getAllItems() {
            return new List<ItemScriptableObject>(itemDictionary.Values);
        }
    }
}