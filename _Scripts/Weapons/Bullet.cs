using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;


namespace Weapons
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : Projectile {
        public override void OnTriggerEnter(Collider other) {
            Health hp = other.gameObject.GetComponent<Health>();
            if (hp) {
                hp.TakeDamage(this.GetDamage());
            }
            Destroy(this.gameObject);
        }
    }
}
