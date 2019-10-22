using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{

    public override void OnTriggerEnter(Collider other) {
        Debug.Log("Collided with " + other.transform.name);
        Health hp = other.gameObject.GetComponent<Health>();
        if (hp) {
            hp.TakeDamage(this.GetDamage());
        }
        Destroy(this.gameObject);
    }

    private void CheckAhead() {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(ray, out hit, GetMovementSpeed()*Time.fixedDeltaTime)) {
            Debug.Log("Checked ahead and collided with " + hit.transform.name);
            Health hp = hit.transform.GetComponent<Health>();
            if (hp) {
                hp.TakeDamage(GetDamage());
            }
            Destroy(this.gameObject);
        }
       
    }

    private void FixedUpdate() {
        //CheckAhead();
    }
}
