using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Items", menuName = "ScriptableObjects/ItemScriptableObject", order = 1)]
    public class ItemScriptableObject : ScriptableObject {
        public string itemName;
        public string description;
        public ItemTypeEnum itemType;
        public Sprite sprite;
        public int cost;
        public bool stackable;
        public GameObject prefab;

        public ItemScriptableObject(string itemName, string description, ItemTypeEnum itemType, Sprite sprite, int cost, bool stackable, GameObject prefab) {
            this.itemName = itemName;
            this.description = description;
            this.itemType = itemType;
            this.sprite = sprite;
            this.cost = cost;
            this.stackable = stackable;
            this.prefab = prefab;
        }

        //Not Actually Required
        /*public static bool operator ==(ItemScriptableObject a, ItemScriptableObject b) {
            if (b) {
                Debug.Log(a.itemName);
                Debug.Log(b.itemName);
                return a.description == b.description && a.itemName == b.itemName && a.itemType == b.itemType;
            } else {
                return false;
            }
        }

        public static bool operator !=(ItemScriptableObject a, ItemScriptableObject b) {
            if (b) {
                return a.description != b.description || a.itemType != b.itemType || a.itemName != b.itemName;
            }
            Debug.Log("For some reason we are trying to compare a value and a non value!!!");
            return false;
        }*/


        public override int GetHashCode() {
            Debug.Log("Getting the hashCode for " + itemName);
            return itemName.GetHashCode() + description.GetHashCode();
        }
    }
    public enum ItemTypeEnum { USABLE, CONSUMABLE, AMMO, WEAPON, QUEST, GENERIC }
}



    