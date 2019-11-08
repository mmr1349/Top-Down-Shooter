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
