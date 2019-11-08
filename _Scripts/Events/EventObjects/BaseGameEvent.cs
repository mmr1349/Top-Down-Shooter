using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Events.Listeners;

namespace Events.EventObjects
{
 /*
 * Extend this object and add an create asset menu under Custom Events/
 * Allows events to pass data to functions
 */
    public abstract class BaseGameEvent<T> : ScriptableObject
    {
          private readonly List<IGameEventListener<T>> eventListents = new List<IGameEventListener<T>>();

          public void Raise(T item)
          {
              
              for (var i = eventListents.Count - 1; i >= 0; i--)
              {
                  eventListents[i].OnEventRaised(item);
              }
          }

          public void RegisterListener(IGameEventListener<T> listener)
          {
              if (!eventListents.Contains(listener))
              {
                  eventListents.Add(listener);
              } 
          }

          public void RemoveListener(IGameEventListener<T> listener)
          {
              if (eventListents.Contains(listener))
              {
                  eventListents.Remove(listener);
              }
          }

          
    }
}
