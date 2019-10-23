using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldWeapon : MonoBehaviour
{
    [SerializeField] private bool canAttack = true;
    [SerializeField] private float coolDownTime;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnLocation;
    

    // Start is called before the first frame update
    void Start() {
        canAttack = true;
    }


    public void Attack() {
        if(canAttack) {
            Instantiate(projectilePrefab, projectileSpawnLocation.position, Quaternion.LookRotation(projectileSpawnLocation.forward));
            canAttack = false;
            StartCoroutine(AttackCoolDown());
        }
    }

    protected IEnumerator AttackCoolDown() {
        yield return new WaitForSeconds(coolDownTime);
        canAttack = true;
    }
}
