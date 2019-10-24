using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items {
    public class MagicWeapon : Weapon {
        [SerializeField] private float manaCost;
        [SerializeField] private GameObject projectile;
        private Mana mana;

        private void Start() {
            mana = GetComponentInParent<Mana>();
        }

        public MagicWeapon(string itemName, string description, int price, Sprite sprite, float coolDown, Transform damageSpawnLocation, GameObject projectile, float manaCost) : base(itemName, description, price, sprite, coolDown, damageSpawnLocation) {
            this.projectile = projectile;
            this.manaCost = manaCost;
        }

        public override void Use() {
            if (getUsable()) {
                if (mana.tryToUseMana(manaCost)) {
                    Debug.Log("We should be shooting " + projectile);
                    setUsable(false);
                    StartCoroutine(setUsableTrue());
                    Instantiate(projectile, getDamageSpawnLocation().position, Quaternion.LookRotation(getDamageSpawnLocation().forward));
                }
            }
        }




    }
}
