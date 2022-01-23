using DialogueSystem.Graph;
using UnityEngine;

[CreateAssetMenu(fileName = "New DoCorruptSO", menuName = "ManagementSystem/DoCorruptSO", order = 0)]
public class DoCorruptSO : DialogueEventSO
{
    public override void RaiseEvent()
    {
        TownDevelopmentManager.Instance.isCorrupt = true;
    }
}