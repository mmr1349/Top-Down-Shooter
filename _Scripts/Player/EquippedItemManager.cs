using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using Items.Inventory;

public class EquippedItemManager : MonoBehaviour {

    [SerializeField] private const int TOOLBAR_SIZE = 3;
    [SerializeField] private List<Equippable> itemList;
    [SerializeField] private int currentIndex;

    private Inventory inventory;
    // Start is called before the first frame update
    void Start() {
        currentIndex = 0;
        itemList = new List<Equippable>();
        itemList.AddRange(GetComponentsInChildren<Equippable>());
        itemList[currentIndex].gameObject.SetActive(true);
        for (int i = 1; i < itemList.Count; i++) {
            itemList[i].gameObject.SetActive(false);
        }
    }

    public Equippable currentyEquipped() {
        return itemList[currentIndex];
    }

    public Equippable EnableEquippableUp() {
        itemList[currentIndex].gameObject.SetActive(false);
        currentIndex++;
        if (currentIndex >= itemList.Count) {
            currentIndex = 0;
        }
        itemList[currentIndex].gameObject.SetActive(true);
        return itemList[currentIndex];
    }

    public Equippable EnableEquippableDown() {
        itemList[currentIndex].gameObject.SetActive(false);
        currentIndex--;
        if (currentIndex < 0) {
            currentIndex = itemList.Count-1;
        }
        itemList[currentIndex].gameObject.SetActive(true);
        return itemList[currentIndex];
    }

    public Equippable EnableEquippableIndex(int index) {
        if (index > 0 && index < itemList.Count) {
            itemList[currentIndex].gameObject.SetActive(false);
            currentIndex = index;
            itemList[currentIndex].gameObject.SetActive(true);
        }
        return itemList[currentIndex];
    }

    public bool transferItemFromInventory(Equippable item) {
        if (itemList.Count < TOOLBAR_SIZE) {
            Vector3 itemPosition = new Vector3(transform.position.x, transform.position.y+1.5f, transform.position.z);
            Equippable instantiatedItem = Instantiate(item.gameObject, itemPosition, Quaternion.identity, transform).GetComponent<Equippable>();
            itemList.Add(instantiatedItem);
            inventory.removeItemFromInventory(item);
            return true;
        }
        return false;
    }

    public bool transferItemIntoInventory(Equippable item) {
        if (itemList.Contains(item)) {
            if (inventory.addItemToInventory(item)) {
                Destroy(item.gameObject);
                itemList.Remove(item);
                return true;
            }
        }
        return false;
    }
}
