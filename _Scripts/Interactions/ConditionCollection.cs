using System.Collections;
using System.Collections.Generic;
using Interactions.Conditions;
using UnityEngine;

namespace Interactions
{
    [CreateAssetMenu(fileName = "New Condition Collection", menuName = "ScriptableObjects/Condition Collection")]
    public class ConditionCollection : ScriptableObject
    {
        [SerializeField] private Condition[] conditions;
        [SerializeField] private ReactionCollection reactionCollection;

        private bool CheckAllConditions()
        {
            foreach (var condition in conditions)
            {
                if (!condition.satasfied)
                {
                    return false;
                }
            }
            //reactionCollection do something
            return true;
        }

        public void Init()
        {
            reactionCollection.Init();
        }

        public ReactionCollection GetReactionCollection()
        {
            return reactionCollection;
        }

        public bool CheckSatisfied()
        {
            foreach (var condition in conditions)
            {
                if (!condition.satasfied)
                    return false;
            }

            return true;
        }
    }
    
}
