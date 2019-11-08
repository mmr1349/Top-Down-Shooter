using UnityEngine;
using Character;

namespace Items {
    public class HealthPotion : Equippable {
        [SerializeField] private float healAmount;

        public override void Use() {
            Health health;
            health = GetComponentInParent<Health>();
            if (health) {
                    health.Heal(healAmount);
                } 
        }
    }
}
