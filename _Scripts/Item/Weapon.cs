using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items {
    public abstract class Weapon : Equippable {
        [SerializeField] private Transform damageSpawnLocation;
        [SerializeField] private float coolDown;
        [SerializeField] private bool usable;

        public IEnumerator setUsableTrue() {
            yield return new WaitForSeconds(coolDown);
            usable = true;
        }

        public float getCoolDown() {
            return coolDown;
        }

        public void setCoolDown(float coolDown) {
            this.coolDown = coolDown;
        }

        public bool getUsable() {
            return usable;
        }

        public void setUsable(bool usable) {
            this.usable = usable;
        }

        public Transform getDamageSpawnLocation() {
            return damageSpawnLocation;
        }

        public void setDamageSpawnLocation(Transform damageSpawnLocation) {
            this.damageSpawnLocation = damageSpawnLocation;
        }
    }
}
