using System;
using DG.Tweening;
using Module;
using UnityEngine;
namespace UI
{
    public abstract class BaseUI : MonoBehaviour, IUserInterfacePreInit
    {
        [DisplayOnly] public bool isFinish = true;

        protected Sequence _inSequence;
        
        /// <summary>
        /// UI进出栈所控制的Transform
        /// </summary>
        protected Transform _controlUITrans;

        /// <summary>
        /// UI进出栈所控制的GameObject
        /// </summary>
        protected GameObject _controlUIGameObj;

        /// <summary>
        /// 当UI开启显示时的回调
        /// </summary>
        protected Action _onUIShow;

        /// <summary>
        /// 当UI关闭显示时的回调 此时UI可能还处在UI栈中
        /// </summary>
        protected Action _onUIHide;
        
        private bool hasDoTween;

        public static T GetController<T>() where T : BaseUI
        {
            return UIResourcesManager.Instance.GetUserInterface<T>();
        }
        
        /// <summary>
        /// 获取UI当前是否存在或是否显示
        /// </summary>
        public virtual bool isActive
        {
            get
            {
                // 外部获取面板活跃状态
                return _controlUIGameObj && _controlUIGameObj.activeSelf;
            }
        }

        protected void SetUIActive()
        {
            _controlUITrans.SetAsLastSibling();
            _controlUIGameObj.SetActive(true);
        }

        protected void SetUIUnActive()
        {
            _controlUIGameObj.SetActive(false);
        }
        
        public virtual void Show()
        {
            SetUIActive();
            if (hasDoTween)
            {
                if (!isFinish) return;
                isFinish = false;
                _inSequence.PlayForward();
            }
            _onUIShow?.Invoke();
        }

        public virtual void Hide()
        {
            if (hasDoTween)
            {
                if (!isFinish) return;
                isFinish = false;
                _inSequence.PlayBackwards();
            }
            else
            {
                SetUIUnActive();
            }
            _onUIHide?.Invoke();
        }
        
        /// <summary>
        /// 在每一次重新载入UI时调用 重写时需要确保调用基类的方法
        /// </summary>
        public virtual void PreInit()
        {
            _inSequence = DOTween.Sequence();
            _inSequence.SetAutoKill(false);
            _inSequence.onComplete += () =>
            {
                isFinish = true;
            };
            // 逆向关闭UI的回调
            _inSequence.onRewind += () =>
            {
                isFinish = true;
                SetUIUnActive();
            };
            hasDoTween = AchieveDoTweenSequence();
            InitControlObj();
        }
        
        /// <summary>
        /// 重写时不需要调用基类的方法 初始化UI动画
        /// </summary>
        /// <returns>是否处理UI动画</returns>
        protected virtual bool AchieveDoTweenSequence()
        {
            return false;
        }

        /// <summary>
        /// 重写时不需要调用基类的方法 初始化控制UI时的Trans和GameObj
        /// </summary>
        protected virtual void InitControlObj()
        {
            _controlUITrans = transform;
            _controlUIGameObj = gameObject;
        }

        /// <summary>
        /// 当UI压入UI栈中的回调
        /// </summary>
        public virtual void OnUIPushIntoStack() {}
        
        /// <summary>
        /// 当UI弹出UI栈中的回调
        /// </summary>
        public virtual void OnUIPopFromStack() {}
    }
}