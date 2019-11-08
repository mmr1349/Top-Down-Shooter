using UnityEngine;
using UnityEngine.UI;
using Items;
using Items.Inventory;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler {
    private Image itemImage;
    private Text amountText;
    [SerializeField]private ItemScriptableObject item;
    [SerializeField] private static InventoryVisual visual;

    private void Awake() {
        if (visual == null) {
            visual = GetComponentInParent<InventoryVisual>();
        }
        itemImage = GetComponentsInChildren<Image>()[1];
        amountText = GetComponentInChildren<Text>();
    }


    public void setItem(ItemScriptableObject item, int amount) {
        this.item = item;
        this.itemImage.sprite = item.sprite;
        this.amountText.text = amount.ToString();
    }

    public void removeItem() {
        this.item = null;
        itemImage.sprite = null;
    }

    private void OnMouseDown() {
        if (item != null) {
            Debug.Log("We have been clicked on " + item.name);
            visual.putItemIntoHotBar(item);
        }
    }

    private void OnMouseOver() {
        if (item != null) {
            Debug.Log("Name: " + item.name);
            Debug.Log("Description: " + item.description);
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (item != null) {
            Debug.Log("Name: " + item.itemName);
            Debug.Log("Description: " + item.description);
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (item != null) {
            Debug.Log("We have been clicked on " + item.itemName);
            visual.putItemIntoHotBar(item);
        }
    }
}
