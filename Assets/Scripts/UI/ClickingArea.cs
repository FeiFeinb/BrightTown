using UnityEngine;
using UnityEngine.EventSystems;

namespace UICore
{
    public class ClickingArea : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            BaseUI.GetController<EnterSceneController>().Show();
        }
    }
}