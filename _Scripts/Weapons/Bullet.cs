using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

namespace Weapons
{
    public class Bullet : Projectile {
        public override void OnTriggerEnter(Collider other) {
            Debug.Log("Collided with " + other.transform.name);
            Health hp = other.gameObject.GetComponent<Health>();
            if (hp) {
                hp.TakeDamage(this.GetDamage());
            }
            Destroy(this.gameObject);
        }
    }
}
