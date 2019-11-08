using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions.Reactions
{
    
    public abstract class Reaction : ScriptableObject
    {
        protected bool isRunning;
        public bool hasBeenPlayed;

        public void Init()
        {
            SpecificInit();
        }
        
        
        protected abstract void SpecificInit();
        
        public bool GetIsRunning()
        {
            return isRunning;
        }

        public void React(MonoBehaviour monoBehaviour)
        {
            ImmediateReaction();
        }

        protected abstract void ImmediateReaction();

        public abstract bool NextStep();
    }

}