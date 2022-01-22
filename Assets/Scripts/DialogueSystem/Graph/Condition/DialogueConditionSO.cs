using UnityEngine;

namespace DialogueSystem.Graph
{
    public abstract class DialogueConditionSO : ScriptableObject
    {
        public virtual void Init(GameObject obj) {}

        public abstract bool Judgment();
    }
}