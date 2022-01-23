using System.Collections.Generic;
using DialogueSystem.Graph;
using ManagementSystem;
using Module;
using UICore;

public class TownDevelopmentManager : BaseSingletonWithMono<TownDevelopmentManager>
{
    public ResourcesPoint playerResource;

    public ScorePoint brightSideScore;

    public ScorePoint darkSideScore;
    
    public List<ChoiceImpactSO> playerChoiceCached = new List<ChoiceImpactSO>();

    public int currentTime = 1;
    
    public void OnPlayerMakeChoice(ChoiceImpactSO choice)
    {
        playerResource += choice.playerResource;
        brightSideScore += choice.brightSideScore;
        darkSideScore += choice.darkSideScore;
        // 走马灯结局缓存
        playerChoiceCached.Add(choice);
    }

    public void SendQuestionnaire()
    {
        BaseUI.GetController<QuestionnaireController>().CreateQuestionnaireDetail(brightSideScore, currentTime);
    }
    
    void End()
    {
        
    }
    
}
