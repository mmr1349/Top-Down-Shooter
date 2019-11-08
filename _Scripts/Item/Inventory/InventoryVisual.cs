using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using Items.Inventory;
using UnityEngine.UI;

public class InventoryVisual : MonoBehaviour {

    [SerializeField] private int rows;
    [SerializeField] private int columns;
    [SerializeField] private int paddingX, paddingY, rowSpacing, columnSpacing;
    [SerializeField] private Inventory inventory;
    [SerializeField] private InventorySlot inventorySlotPrefab;
    [SerializeField] private InventorySlot[,] inventoryPositions;

    private EquippedItemManager equippedItems;

    private void Start() {
        equippedItems = GameObject.FindGameObjectWithTag("Player").GetComponent<EquippedItemManager>();
        inventory.ourInventoryChanged += displayItemsFromInventory;
        createInventoryGrid();
        displayItemsFromInventory();
    }

    private void FixedUpdate() {
        //displayItemsFromInventory();
    }

    private void createInventoryGrid() {
        inventoryPositions = new InventorySlot[columns, rows];
        for (int x = 0; x < columns; x++) {
            for (int y = 0; y < rows; y++) {
                //Vector3 slotPosition = new Vector3(transform.position.x-(transform.position.x/2)+paddingX + (x*columnSpacing), transform.position.y-(transform.position.y/2) + paddingY + (y * rowSpacing));
                inventoryPositions[x, y] = Instantiate(inventorySlotPrefab.gameObject, transform.GetChild(0)).GetComponent<InventorySlot>();
            }
        }
    }

    public void putItemIntoHotBar(ItemScriptableObject item) {
        Debug.Log("Freaking work " + item);
        Debug.Log("Item " + item.itemName + " made it to visual.");
        if (item.itemType == ItemTypeEnum.USABLE) {
            Debug.Log("Trying to equip usable item: " + item.itemName);
            equippedItems.transferItemFromInventory(item);
            displayItemsFromInventory();
        } else {
            Debug.Log("This item is not equippable " + item.name);
        }
    }

    private void displayItemsFromInventory() {
        List<ItemScriptableObject> items = inventory.getAllItems();
        int count = 0;
        for (int c = 0; c < columns; c++) {
            for (int r = 0; r < rows; r++) {
                if (count >= items.Count) {
                    inventoryPositions[c, r].removeItem();
                } else {
                    inventoryPositions[c, r].setItem(items[count], inventory.getItemAmount(items[count]));
                    count++;
                }
            }
        }
    }
}
