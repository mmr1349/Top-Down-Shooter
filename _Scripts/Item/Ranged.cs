using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items {
    public class Ranged : Weapon {
        [SerializeField] private Ammo ammo;

        public Ranged(string itemName, string description, int price, Sprite sprite, float coolDown, Transform damageSpawnLocation, Ammo ammo) : base(itemName, description, price, sprite, coolDown, damageSpawnLocation) {
            this.ammo = ammo;
        }

        public override void Use() {
            if (getUsable()) {
                if(ammo.getAmount() > 0) {
                    Debug.Log("We should be shooting " + ammo.getItemName());
                    setUsable(false);
                    StartCoroutine(setUsableTrue());
                    GameObject projectile = ammo.getProjectile();
                    ammo.Use();
                    Instantiate(projectile, getDamageSpawnLocation().position, Quaternion.LookRotation(getDamageSpawnLocation().forward));
                }
            }
        }
    }
}
