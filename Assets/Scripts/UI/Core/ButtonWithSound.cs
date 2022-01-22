    using Module;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class ButtonWithSound : Button
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            CenterEvent.Instance.Raise(GlobalEventID.ButtonClick);
        }
    }
