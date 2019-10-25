using UnityEngine;
using UnityEngine.UI;
using Items;
public class InventorySlot : MonoBehaviour {
    private Image itemImage;
    [SerializeField]private Item item;

    private void Awake() {
        itemImage = GetComponentsInChildren<Image>()[1];
    }


    public void setItem(Item item) {
        this.item = item;
        itemImage.sprite = item.getSprite();
    }
}
