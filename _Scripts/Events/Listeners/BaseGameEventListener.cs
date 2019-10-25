using System.Collections;
using System.Collections.Generic;
using Events.EventObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Events.Listeners
{
/*
 * In order to have a new event listener, extend a new class off of this one
 * T - The type of event
 * E - The event object that is called/listened for
 * UER - What happens when the event is called
 */
    public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour,
        IGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T>
    {
        [SerializeField] private E gameEvent;

        public E GameEvent
        {
            get => gameEvent;
            set => gameEvent = value;
        }

        [SerializeField] private UER unityEventRespone;

        private void OnEnable()
        {
            if (gameEvent == null)
            {
                return;
            }

            GameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (gameEvent == null)
            {
                return;
            }

            GameEvent.RemoveListener(this);
        }

        public void OnEventRaised(T item)
        {
            unityEventRespone.Invoke(item);
        }
    }

   
}