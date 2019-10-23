using System;
using Interactions.Conditions;
using Interactions.Reactions;
using TMPro;
using UnityEngine;

namespace Interactions
{
    [CreateAssetMenu(fileName = "New String Condition Reaction",menuName = "ScriptableObjects/Condition String Reaction Group")]
    public class ConditionStringReactionGroup : ScriptableObject
    {
        [SerializeField] private Condition condition;
        [SerializeField] private TextReaction reaction;

        [SerializeField] private TextMeshProUGUI displayArea;
        
        
    }
}