using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour {
        [SerializeField] private ItemScriptableObject data;
        
        public ItemScriptableObject getScripatbleObject() {
            return data;
        }

        private void Awake() {
            //data.prefab = this.gameObject;
        }
    }
}
