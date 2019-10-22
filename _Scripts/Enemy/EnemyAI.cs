using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] private float walkRadius;
    [SerializeField] private float attackRange;
    [SerializeField] private float patrolSpeed;
    [SerializeField] private float alertSpeed;

    public enum EnemyState { PATROL, SUSPICIOUS, ALERTED };

    private EnemyState myState, previousState;
    private NavMeshAgent navAgent;
    private Vector3 currentTArget;
    private static Transform playerTransform;
    private Weapon myWeapon;

    // Start is called before the first frame update
    void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        myState = EnemyState.PATROL;
        previousState = myState;
        navAgent = GetComponent<NavMeshAgent>();
        currentTArget = getRandomTarget();
        navAgent.SetDestination(currentTArget);
        myWeapon = GetComponentInChildren<Weapon>();
    }


    private Vector3 getRandomTarget() {
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
        return hit.position;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (myState == EnemyState.PATROL) {
            if (!navAgent.hasPath) {
                Debug.Log("Getting new destination");
                currentTArget = getRandomTarget();
                navAgent.SetDestination(currentTArget);
                navAgent.stoppingDistance = 1f;
                navAgent.speed = patrolSpeed;
            }
        } else if (myState == EnemyState.SUSPICIOUS) {
            if (!navAgent.hasPath) {
                Debug.Log("Getting new destination");
                currentTArget = getRandomTarget();
                navAgent.SetDestination(currentTArget);
                navAgent.stoppingDistance = 1f;
                navAgent.speed = patrolSpeed;
            }
        } else if (myState == EnemyState.ALERTED) {
            navAgent.stoppingDistance = 0f;
            navAgent.speed = alertSpeed;
            if (!Vector3InRange(navAgent.pathEndPosition, playerTransform.position, 1f)) {
                currentTArget = playerTransform.position;
                navAgent.SetDestination(currentTArget);
            } if (Vector3InRange(transform.position, playerTransform.position, attackRange)) {
                navAgent.velocity = Vector3.Lerp(navAgent.velocity, Vector3.zero, Time.fixedDeltaTime*5f);
                navAgent.isStopped = true;
                navAgent.ResetPath();
                transform.LookAt(playerTransform);
                myWeapon.Attack();
            } else {
                navAgent.isStopped = false;
            }
        }
    }

    private bool Vector3InRange(Vector3 a, Vector3 b, float range) {
        float distance = Vector3.Distance(a, b);
        return distance <= range;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            myState = EnemyState.ALERTED;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            myState = EnemyState.SUSPICIOUS;
        }
    }
}
