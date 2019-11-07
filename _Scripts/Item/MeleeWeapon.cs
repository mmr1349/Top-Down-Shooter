using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items {
    public class MeleeWeapon : Weapon {
        [SerializeField] private GameObject damagerObject;
        private Animator animator;

        private void Start() {
            animator = GetComponent<Animator>();
            setUsable(true);
        }

        public override void Use() {
            if(getUsable()) {
                setUsable(false);
                StartCoroutine(setUsableTrue());
                Instantiate(damagerObject, getDamageSpawnLocation()).transform.forward = this.transform.forward;
            }
        }
    }
}
