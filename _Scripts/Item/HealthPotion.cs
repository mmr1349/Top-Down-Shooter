using Character;
using UnityEngine;

namespace Items {
    public class HealthPotion : Consumable {
        [SerializeField] private float healAmount;

        public HealthPotion(string itemName, int healAmount, Sprite sprite, int price, int amount) : base(itemName, "Heals you " + healAmount + " health points.", price, sprite, amount) {
            this.healAmount = healAmount;
        }

        public override void Use() {
            if (getAmount() > 0) {
                setAmount(getAmount() - 1);
                Health health;
                health = GetComponentInParent<Health>();
                if (health) {
                    health.Heal(healAmount);
                }
                else {
                    Debug.LogWarning(getItemName() + ": we are not equipped to an object with a health");
                }
                if (getAmount() <= 0) {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
