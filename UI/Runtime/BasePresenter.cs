using System;
using UnityEngine;

namespace ModulesGT.UI 
{
    public abstract class BasePresenter : MonoBehaviour
    {
        public event Action OnClose;
        public virtual void Show(IPresenterData data, Action onShow)
        {
            onShow?.Invoke();
        }

        public virtual void Close(Action onClose = null)
        {
            OnClose?.Invoke();
            onClose?.Invoke();
            Destroy(gameObject);
        }
    }
    
    public interface IPresenterData
    {
        
    }
}