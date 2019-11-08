using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using Items.Inventory;

public class ItemPickup : MonoBehaviour {
    [SerializeField] private ItemScriptableObject item;
    [SerializeField] private int amount;
    private static Camera mainCamera;
    private SpriteRenderer sprite;

    private void Start() {
        if (mainCamera == null) {
            mainCamera = Camera.main;
        }
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = item.sprite;
    }

    private void LateUpdate() {
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
            mainCamera.transform.rotation * Vector3.up);
    }

    private void OnCollisionEnter(Collision collision) {
        Inventory inventory = collision.transform.GetComponent<Inventory>();
        if (inventory) {
            inventory.addItemToInventory(item, amount);
            Destroy(this.gameObject);
        }
    }


    public void setItem(ItemScriptableObject item) {
        this.item = item;
    }
}
