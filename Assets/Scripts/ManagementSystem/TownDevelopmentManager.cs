using System.Collections.Generic;
using DialogueSystem.GamePlay;
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

    public bool isCorrupt = false;
    
    public void OnPlayerMakeChoice(ChoiceImpactSO choice)
    {
        playerResource += choice.playerResource;
        brightSideScore += choice.brightSideScore;
        darkSideScore += choice.darkSideScore;
        // 走马灯结局缓存
        playerChoiceCached.Add(choice);
    }

    public void EndGame()
    {
        BaseUI.GetController<EndingController>().CreateEndingResult(playerChoiceCached);
        BaseUI.GetController<EndingController>().Show();
        StoryLine.Instance.ResetStoryLine();
    }
    
    public void SendQuestionnaire()
    {
        BaseUI.GetController<QuestionnaireController>().CreateQuestionnaireDetail(brightSideScore, currentTime);
    }
    
}
