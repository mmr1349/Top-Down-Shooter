using UnityEngine.Events;

namespace Events.CustomEvents
{
    [System.Serializable]
    public struct Void{}

    [System.Serializable]
    public class VoidEvent : UnityEvent<Void>
    {
        
    }
}