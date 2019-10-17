using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    public override void OnCollisionEnter(Collision collision) {
        Debug.Log("Collided with " + collision.transform.name);
    }
}
