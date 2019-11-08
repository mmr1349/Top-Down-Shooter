using System.Collections;
using System.Collections.Generic;
using Events.EventObjects;
using Interactions.Reactions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

namespace UI
{
    
    public class TextManager : MonoBehaviour
    {
        private static TextManager instance;
        [SerializeField] private TextMeshProUGUI textDisplay;
        [SerializeField] private VoidEventObject allowMovement;
        private bool currentlyInteracting;
        private Reaction currentReaction;
        

        void Awake()
        {
            if (!instance)
            {
                instance = this;
            }
            else
            {
                Debug.LogWarning("Too many Text Managers");
                Destroy(this.gameObject);
            }
        }
    
        // Start is called before the first frame update
        void Start()
        {
            textDisplay.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            
            if(currentlyInteracting)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (!currentReaction.NextStep())
                    {
                        currentlyInteracting = false;
                        textDisplay.gameObject.SetActive(false);
                        allowMovement.Raise();
                    }
                }
            }
        }

        public void TriggerReaction(Reaction reaction)
        {
            if (!currentlyInteracting)
            {
                currentlyInteracting = true;
                reaction.React(textDisplay);
                currentReaction = reaction;

            }
            else
            {
                Debug.LogError("Can't run multiple reactions at once");
            }
        }

        public void SetText(string text)
        {
            textDisplay.gameObject.SetActive(true);
            textDisplay.text = text;
        }
    }

}