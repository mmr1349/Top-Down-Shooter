using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float amount) {
        health -= amount;
        if (health <= 0) {
            Debug.Log("We have died.");
        }
    }
}
