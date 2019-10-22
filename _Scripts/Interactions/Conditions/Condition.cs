using UnityEngine;

namespace Interactions.Conditions
{
    [CreateAssetMenu(fileName = "New Condition", menuName = "ScriptableObjects/Condition")]
    public class Condition : ScriptableObject
    {
        public string description;
        public bool satasfied;
    }
}