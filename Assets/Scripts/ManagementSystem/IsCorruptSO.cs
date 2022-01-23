using DialogueSystem.Graph;
using UnityEngine;

[CreateAssetMenu(fileName = "New IsCorruptSO", menuName = "ManagementSystem/IsCorruptSO", order = 0)]
public class IsCorruptSO : DialogueConditionSO
{
    public override bool Judgment()
    {
        return TownDevelopmentManager.Instance.isCorrupt;
    }
}