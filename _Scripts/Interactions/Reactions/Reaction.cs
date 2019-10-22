using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions.Reactions
{
    
    public abstract class Reaction<T> : MonoBehaviour
    {
        [SerializeField] private List<T> reactionItems;
        public bool hasBeenPlayed;
        private int index = 0;

        public T getNextReaction()
        {
            index++;
            return reactionItems[index];
        }

        public T getPreviousReactin()
        {
            index--;
            return reactionItems[index];
        }

        public bool tryNextReaction()
        {
            return index < reactionItems.Count;
        }

        public bool tryPreviousReaction()
        {
            return index >= 0;
        }
    }

}