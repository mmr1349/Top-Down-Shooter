using System;
using Events.EventObjects;
using UnityEngine;
using Void = Events.CustomEvents.Void;

namespace Interactions.Options
{
    [CreateAssetMenu(fileName = "New Option",menuName = "ScriptableObjects/Option")]
    public class Option : ScriptableObject
    {
        [SerializeField] private VoidEventObject eventToCall;//TODO find a way for it to take any event
        [SerializeField] private string title;

        public string GetTitle()
        {
            return title;
        }

        public BaseGameEvent<Void> GetEventToCall()
        {
            return eventToCall;
        }
    }
}