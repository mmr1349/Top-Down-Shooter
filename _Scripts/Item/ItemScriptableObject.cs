using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Items", menuName = "ScriptableObjects/ItemScriptableObject", order = 1)]
    public class ItemScriptableObject : ScriptableObject {
        public string name;
        public string description;
        public ItemTypeEnum itemType;
        public Sprite sprite;
        public int cost;
        public bool stackable;
        public GameObject prefab;
        public int amount;

        public ItemScriptableObject(string name, string description, ItemTypeEnum itemType, Sprite sprite, int cost, bool stackable, GameObject prefab, int amount) {
            this.name = name;
            this.description = description;
            this.itemType = itemType;
            this.sprite = sprite;
            this.cost = cost;
            this.stackable = stackable;
            this.prefab = prefab;
            this.amount = amount;
        }

        public static bool operator ==(ItemScriptableObject a, ItemScriptableObject b) {
            return a.description == b.description && a.name == b.name && a.itemType == b.itemType;
        }

        public static bool operator !=(ItemScriptableObject a, ItemScriptableObject b) {
            return a.description != b.description || a.name != b.name || a.itemType != b.itemType;
        }
    }

    public enum ItemTypeEnum {
        USABLE, CONSUMABLE, AMMO, WEAPON, QUEST
    }
}