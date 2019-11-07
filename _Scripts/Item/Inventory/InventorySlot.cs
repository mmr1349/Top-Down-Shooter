using UnityEngine;
using UnityEngine.UI;
using Items;
using Items.Inventory;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler {
    private Image itemImage;
    [SerializeField]private ItemScriptableObject item;
    [SerializeField] private static InventoryVisual visual;

    private void Awake() {
        if (visual == null) {
            visual = GetComponentInParent<InventoryVisual>();
        }
        itemImage = GetComponentsInChildren<Image>()[1];
    }


    public void setItem(ItemScriptableObject item) {
        this.item = item;
        itemImage.sprite = item.sprite;
    }

    public void removeItem() {
        this.item = null;
        itemImage.sprite = null;
    }

    private void OnMouseDown() {
        Debug.Log("We have been clicked on " + item.name);
        visual.putItemIntoHotBar(item);
    }

    private void OnMouseOver() {
        Debug.Log("Name: " + item.name);
        Debug.Log("Description: " + item.description);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("Name: " + item.name);
        Debug.Log("Description: " + item.description);
    }

    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("We have been clicked on " + item.name);
        visual.putItemIntoHotBar(item);
    }
}
