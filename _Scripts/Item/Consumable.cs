using UnityEngine;

namespace Items {
    public abstract class Consumable : Usable
    {
        [SerializeField] private int amount;

        public Consumable(string itemName, string description, int price, Sprite sprite, int amount) : base(itemName, description, price, sprite) {
            this.amount = amount;
        }

        public int getAmount() {
            return amount;
        }

        public void setAmount(int amount) {
            this.amount = amount;
        }
    }
}