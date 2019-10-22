using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedItemManager : MonoBehaviour
{
    [SerializeField] private List<Weapon> weaponList;
    [SerializeField] private int currentIndex;
    // Start is called before the first frame update
    void Start() {
        currentIndex = 0;
        weaponList = new List<Weapon>();
        weaponList.AddRange(GetComponentsInChildren<Weapon>());
        weaponList[currentIndex].gameObject.SetActive(true);
        for (int i = 1; i < weaponList.Count; i++) {
            weaponList[i].gameObject.SetActive(false);
        }
    }

    public Weapon EnableWeaponUp() {
        weaponList[currentIndex].gameObject.SetActive(false);
        currentIndex++;
        if (currentIndex >= weaponList.Count) {
            currentIndex = 0;
        }
        weaponList[currentIndex].gameObject.SetActive(true);
        return weaponList[currentIndex];
    }

    public Weapon EnableWeaponDown() {
        weaponList[currentIndex].gameObject.SetActive(false);
        currentIndex--;
        if (currentIndex < 0) {
            currentIndex = weaponList.Count-1;
        }
        weaponList[currentIndex].gameObject.SetActive(true);
        return weaponList[currentIndex];
    }

    public Weapon EnableWeaponIndex(int index) {
        if (index > 0 && index < weaponList.Count) {
            weaponList[currentIndex].gameObject.SetActive(false);
            currentIndex = index;
            weaponList[currentIndex].gameObject.SetActive(true);
        }
        return weaponList[currentIndex];
    }
}
