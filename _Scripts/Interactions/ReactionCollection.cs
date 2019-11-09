using System.Collections;
using System.Collections.Generic;
using Interactions.Reactions;
using UnityEngine;

namespace Interactions
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Reaction Collection",fileName = "New Reaction Collection")]
    public class ReactionCollection : ScriptableObject
    {
        [SerializeField] private Reaction[] reactions;
        private int index = 0;

        public bool TryNextReaction()
        {
            return index + 1 < reactions.Length;
        }

        public Reaction GetNextReaction()
        {
            var toReturn = reactions[index];
            
            index++;
            return toReturn;
        }

        public void Init()
        {
            
            index = 0;
            foreach (var reaction in reactions)
            {
                reaction.Init();
            }
        }
    }
    
}
