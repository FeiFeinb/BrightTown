using UnityEngine;

namespace Module
{
    public abstract class BaseUIPanel : MonoBehaviour
    {
        public virtual void Init() {}

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}