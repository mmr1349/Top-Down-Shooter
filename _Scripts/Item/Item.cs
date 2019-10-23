using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private string itemName;
        [SerializeField] private string description;
        [SerializeField] private int price;
        [SerializeField] private Sprite sprite;

        public Item(string itemName, string description, int price, Sprite sprite) {
            this.itemName = itemName;
            this.description = description;
            this.price = price;
            this.sprite = sprite;
        }

        public string getItemName() {
            return itemName;
        }

        public string getDescription() {
            return description;
        }

        public int getPrice() {
            return price;
        }

        public Sprite getSprite() {
            return sprite;
        }

        public void setItemName(string itemName) {
            this.itemName = itemName;
        }

        public void setDescription(string description) {
            this.description = description;
        }

        public void setPrice(int price) {
            this.price = price;
        }

        public void setSprite(Sprite sprite) {
            this.sprite = sprite;
        }
    }
}
