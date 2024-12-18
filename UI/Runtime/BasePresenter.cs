using System;
using UnityEngine;

namespace ModulesGT.UI 
{
    public class BasePresenter : MonoBehaviour
    {
        public virtual void Show(IPresenterData data, Action onShow)
        {
            onShow?.Invoke();
        }

        public virtual void Close(Action onClose)
        {
            onClose?.Invoke();
            Destroy(gameObject);
        }
    }
    
    public interface IPresenterData
    {
        
    }
}