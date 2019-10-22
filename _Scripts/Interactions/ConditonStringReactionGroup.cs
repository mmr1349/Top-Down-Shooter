using System;
using Interactions.Conditions;
using Interactions.Reactions;
using UnityEngine;

namespace Interactions
{
    public class ConditonStringReactionGroup : ScriptableObject
    {
        [SerializeField] private Condition condition;
        [SerializeField] private Reaction<string>[] reaction;
    }
}