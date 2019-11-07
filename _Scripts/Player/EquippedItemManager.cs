using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using Items.Inventory;

public class EquippedItemManager : MonoBehaviour {

    [SerializeField] private const int TOOLBAR_SIZE = 3;
    [SerializeField] private List<Equippable> weaponGameObjectList;
    [SerializeField] private int currentIndex;

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

    public bool transferItemFromInventory(Equippable item) {
        if (weaponGameObjectList.Count < TOOLBAR_SIZE) {
            Vector3 itemPosition = new Vector3(transform.position.x, transform.position.y+1.5f, transform.position.z);
            Equippable instantiatedItem = Instantiate(item.gameObject, itemPosition, Quaternion.identity, transform).GetComponent<Equippable>();
            weaponGameObjectList.Add(instantiatedItem);
            inventory.removeItemsFromInventory(item.getScripatbleObject(), 1);
            return true;
        }
        return false;
    }

    public bool transferItemIntoInventory(Equippable item) {
        if (weaponGameObjectList.Contains(item)) {
            if (inventory.addItemToInventory(item.getScripatbleObject())) {
                Destroy(item.gameObject);
                weaponGameObjectList.Remove(item);
                return true;
            }
        }
        return false;
    }
}
