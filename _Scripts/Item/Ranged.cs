using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items {
    public class Ranged : Weapon {
        [SerializeField] private Ammo ammo;
        [SerializeField] private GameObject projectile;

        public override void Use() {
            if (getUsable()) {
                setUsable(false);
                StartCoroutine(setUsableTrue());
                //GameObject projectile = ammo.gameObject;
                Instantiate(projectile, getDamageSpawnLocation().position, Quaternion.LookRotation(getDamageSpawnLocation().forward));
            }
        }
    }
}
