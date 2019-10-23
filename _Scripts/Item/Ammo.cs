using UnityEngine;

namespace Items {
    public class Ammo : Consumable {
        [SerializeField] private GameObject projectilePrefab;

        public Ammo(string itemName, string description, int price, Sprite sprite, int amount, GameObject projectilePrefab) : base(itemName, description, price, sprite, amount) {
            this.projectilePrefab = projectilePrefab;
        }

        public override void Use() {
            setAmount(getAmount() - 1);
            if (getAmount() <= 0) {
                Debug.Log("Ran out of " + getItemName() + " destroying ourself.");
                Destroy(this);
            }
        }

        public GameObject getProjectile() {
            return projectilePrefab;
        }

        public void setProjectilePrefab(GameObject projectilePrefab) {
            this.projectilePrefab = projectilePrefab;
        }
    }
}
