using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using Character;

[RequireComponent(typeof(Health))]
public class DropItemsOnDie : MonoBehaviour {
    [SerializeField] private List<ItemScriptableObject> lootTable;
    [SerializeField] private ItemPickup pickupPrefab;
    [SerializeField] private int minItems;
    [SerializeField] private int maxItems;

    private void Start() {
        GetComponent<Health>().ourDieDelegate += onDie;
    }

    public void onDie() {
        int amount = Random.Range(minItems, maxItems);
        for (int i = 0; i < amount; i++) {
            ItemPickup pickup = Instantiate(pickupPrefab.gameObject, transform.position, Quaternion.identity).GetComponent<ItemPickup>();
            pickup.setItem(lootTable[Random.Range(0, lootTable.Count-1)]);
            pickup.GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere * 100f, ForceMode.Impulse);
        }
    }
}
