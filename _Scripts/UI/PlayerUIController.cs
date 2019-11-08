using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Character;
using Player;

namespace UI
{
    
    public class PlayerUIController : MonoBehaviour {
        [SerializeField] private Slider healthBar;
        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private Slider manaBar;
        [SerializeField] private TextMeshProUGUI manaText;
        [SerializeField] private Image itemSprite;

        private Health playerHealth;
        private Mana playerMana;
        private EquippedItemManager itemManager;

        // Start is called before the first frame update
        void Start() {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<Mana>();
            itemManager = GameObject.FindGameObjectWithTag("Player").GetComponent<EquippedItemManager>();
        }

        // Update is called once per frame
        void Update() {
            healthBar.value = playerHealth.GetHealth() / playerHealth.GetMaxHealth();
            healthText.text = Mathf.Round(playerHealth.GetHealth()).ToString();
            manaBar.value = playerMana.getManaAmount() / playerMana.getMaxManaAmount();
            manaText.text = Mathf.Round(playerMana.getManaAmount()).ToString();
            itemSprite.sprite = itemManager.currentyEquipped().getSprite();
        }
    }
}