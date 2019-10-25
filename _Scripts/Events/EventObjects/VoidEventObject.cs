using Events.CustomEvents;
using UnityEngine;

namespace Events.EventObjects
{
    [CreateAssetMenu(fileName = "New Void Event ", menuName = "Custom Events/Void Event")]
    public class VoidEventObject : BaseGameEvent<Void>
    {
        public void Raise() => Raise(new Void());
    }
}