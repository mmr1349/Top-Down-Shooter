using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using Items.Inventory;

public class EquippedItemManager : MonoBehaviour {

    [SerializeField] private const int TOOLBAR_SIZE = 10;
    [SerializeField] private List<Equippable> weaponGameObjectList;
    [SerializeField] private int currentIndex;
    [SerializeField] private Transform weaponSpawnLocation;

    private Inventory inventory;
    // Start is called before the first frame update
    void Start() {
        currentIndex = 0;
        weaponGameObjectList = new List<Equippable>();
        weaponGameObjectList.AddRange(GetComponentsInChildren<Equippable>());
        for (int i = 1; i < weaponGameObjectList.Count; i++) {
            weaponGameObjectList[i].gameObject.SetActive(false);
        }
        weaponGameObjectList[currentIndex].gameObject.SetActive(true);
        inventory = GetComponent<Inventory>();
    }

    public Equippable currentyEquipped() {
        return weaponGameObjectList[currentIndex];
    }

    public Equippable EnableEquippableUp() {
        weaponGameObjectList[currentIndex].gameObject.SetActive(false);
        currentIndex++;
        if (currentIndex >= weaponGameObjectList.Count) {
            currentIndex = 0;
        }
        weaponGameObjectList[currentIndex].gameObject.SetActive(true);
        return weaponGameObjectList[currentIndex];
    }

    public Equippable EnableEquippableDown() {
        weaponGameObjectList[currentIndex].gameObject.SetActive(false);
        currentIndex--;
        if (currentIndex < 0) {
            currentIndex = weaponGameObjectList.Count-1;
        }
        weaponGameObjectList[currentIndex].gameObject.SetActive(true);
        return weaponGameObjectList[currentIndex];
    }

    public Equippable EnableEquippableIndex(int index) {
        if (index > 0 && index < weaponGameObjectList.Count) {
            weaponGameObjectList[currentIndex].gameObject.SetActive(false);
            currentIndex = index;
            weaponGameObjectList[currentIndex].gameObject.SetActive(true);
        }
        return weaponGameObjectList[currentIndex];
    }

    public bool transferItemFromInventory(ItemScriptableObject item) {
        if (weaponGameObjectList.Count < TOOLBAR_SIZE) {
            Debug.Log("Trying to remove item from inventory: " + item.itemName);
            if (inventory.removeItemsFromInventory(item, 1)) {
                Equippable instantiatedItem = Instantiate(item.prefab, weaponSpawnLocation.position, weaponSpawnLocation.rotation, transform).GetComponent<Equippable>();
                weaponGameObjectList.Add(instantiatedItem);
                instantiatedItem.gameObject.SetActive(false);
                return true;
            }
        }
        return false;
    }

    public bool transferItemIntoInventory(Equippable item) {
        if (weaponGameObjectList.Contains(item)) {
            if (inventory.addItemToInventory(item.getScripatbleObject(), 1)) {
                Destroy(item.gameObject);
                weaponGameObjectList.Remove(item);
                return true;
            }
        }
        return false;
    }
}
