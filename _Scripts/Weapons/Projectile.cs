using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private float damage;
        [SerializeField] private GameObject owner;
        [SerializeField] private float lifetime;

        private Rigidbody rBody;

        // Start is called before the first frame update
        void Start() {
            rBody = GetComponent<Rigidbody>();
            rBody.velocity = transform.forward * movementSpeed;
            StartCoroutine(DestroyAfter());
        }

        protected IEnumerator DestroyAfter() {
            yield return new WaitForSeconds(lifetime);
            Destroy(this.gameObject);
        }

        public float GetDamage() {
            return damage;
        }

        public float GetMovementSpeed() {
            return movementSpeed;
        }

        public abstract void OnCollisionEnter(Collision collision);
    }

}
