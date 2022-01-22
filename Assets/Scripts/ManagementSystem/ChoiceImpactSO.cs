using DialogueSystem.Graph;
using UnityEngine;

namespace ManagementSystem
{
    [CreateAssetMenu(fileName = "New ChoiceImpactSO", menuName = "ManagementSystem", order = 0)]
    public class ChoiceImpactSO : DialogueEventSO
    {
        public ResourcesPoint playerResource;

        public ScorePoint brightSideScore;

        public ScorePoint darkSideScore;

        public string choiceName;
        
        public override void RaiseEvent()
        {
            TownDevelopmentManager.Instance.OnPlayerMakeChoice(this);
        }
    }
}