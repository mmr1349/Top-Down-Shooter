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

        public ItemScriptableObject(string name, string description, ItemTypeEnum itemType, Sprite sprite, int cost, bool stackable, GameObject prefab) {
            this.name = name;
            this.description = description;
            this.itemType = itemType;
            this.sprite = sprite;
            this.cost = cost;
            this.stackable = stackable;
            this.prefab = prefab;
        }
    }

    public enum ItemTypeEnum {
        USABLE, CONSUMABLE, AMMO, WEAPON, QUEST
    }
}