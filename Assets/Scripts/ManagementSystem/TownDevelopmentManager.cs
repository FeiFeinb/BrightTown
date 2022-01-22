using System.Collections.Generic;
using DialogueSystem.Graph;
using ManagementSystem;
using Module;

public class TownDevelopmentManager : BaseSingletonWithMono<TownDevelopmentManager>
{
    public ResourcesPoint playerResource;

    public ScorePoint brightSideScore;

    public ScorePoint darkSideScore;
    
    public List<ChoiceImpactSO> playerChoiceCached = new List<ChoiceImpactSO>();

    // 是否是黑夜
    public bool isSunny = true;

    // 是否白天
    public bool isDay = true;
    
    public void OnPlayerMakeChoice(ChoiceImpactSO choice)
    {
        playerResource += choice.playerResource;
        brightSideScore += choice.brightSideScore;
        darkSideScore += choice.darkSideScore;
        // 走马灯结局缓存
        playerChoiceCached.Add(choice);
    }

    void End()
    {
        
    }
    
}
