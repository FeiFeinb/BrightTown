using System.Collections.Generic;
using DialogueSystem.Graph.Events;
using DialogueSystem.Graph;
using Module;

namespace DialogueSystem.Graph
{
    public class DialogueHandler : BaseSingleton<DialogueHandler>
    {
        public readonly Dictionary<DialogueConditionType, IDialogueConditionHandler> ConditionHandlers = new Dictionary<DialogueConditionType, IDialogueConditionHandler>();
        
        public readonly Dictionary<DialogueEventType, IDialogueEventHandler> EventHandlers =
            new Dictionary<DialogueEventType, IDialogueEventHandler>();
        
        public DialogueHandler()
        {
            ConditionHandlers.Add(DialogueConditionType.Others, new DialogueOtherConditionConditionHandler());
            EventHandlers.Add(DialogueEventType.Others, new DialogueOtherEventsConditionHandler());
        }
    }
}