using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

namespace Player
{
    public class EquippedItemManager : MonoBehaviour {

    [SerializeField] private const int TOOLBAR_SIZE = 10;
    [SerializeField] private List<Equippable> weaponGameObjectList;
    [SerializeField] private int currentIndex;
    // Start is called before the first frame update
    void Start() {
        currentIndex = 0;
        itemList = new List<Usable>();
        itemList.AddRange(GetComponentsInChildren<Usable>());
        itemList[currentIndex].gameObject.SetActive(true);
        for (int i = 1; i < itemList.Count; i++) {
            itemList[i].gameObject.SetActive(false);
        }
    }

    public Usable currentyEquipped() {
        return itemList[currentIndex];
    }

    public Usable EnableUsableUp() {
        itemList[currentIndex].gameObject.SetActive(false);
        currentIndex++;
        if (currentIndex >= itemList.Count) {
            currentIndex = 0;
        }
        itemList[currentIndex].gameObject.SetActive(true);
        return itemList[currentIndex];
    }

    public Usable EnableUsableDown() {
        itemList[currentIndex].gameObject.SetActive(false);
        currentIndex--;
        if (currentIndex < 0) {
            currentIndex = itemList.Count-1;
        }
        itemList[currentIndex].gameObject.SetActive(true);
        return itemList[currentIndex];
    }

    public Usable EnableUsableIndex(int index) {
        if (index > 0 && index < itemList.Count) {
            itemList[currentIndex].gameObject.SetActive(false);
            currentIndex = index;
            itemList[currentIndex].gameObject.SetActive(true);
        }
        return itemList[currentIndex];
    }
}

}