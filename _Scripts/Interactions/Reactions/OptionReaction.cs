using System.Collections;
using System.Collections.Generic;
using Events.CustomEvents;
using Events.EventObjects;
using Interactions.Options;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Interactions.Reactions
{
    [CreateAssetMenu(fileName = "New option Reaction",menuName = "ScriptableObjects/Reactions/Option Reaction")]
    public class OptionReaction : Reaction
    {
        [SerializeField] private Option[] options;
        [SerializeField] private GameObject optionGameObject;
        [SerializeField] private VoidEventObject optionChoosen;
        protected override void SpecificInit()
        {
            
        }

        protected override void ImmediateReaction()
        {
            foreach (var option in options)
            {
                var buttonInstance = Instantiate(optionGameObject, reactionObjectInstance.transform);
                buttonInstance.GetComponentInChildren<TextMeshProUGUI>().text = option.GetTitle();
                buttonInstance.GetComponent<Button>().onClick.AddListener(() =>
                {
                    option.GetEventToCall().Raise(new Void());
                    optionChoosen.Raise(new Void());
                });
            }
        }

        public override bool NextStep()
        {
            return false;
        }
    }

}