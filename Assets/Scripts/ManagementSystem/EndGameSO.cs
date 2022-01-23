using DialogueSystem.Graph;
using UnityEngine;

[CreateAssetMenu(fileName = "New EndGameSO", menuName = "ManagementSystem/New EndGameSO", order = 0)]
public class EndGameSO : DialogueEventSO
{
    public override void RaiseEvent()
    {
        TownDevelopmentManager.Instance.EndGame();
    }
}
