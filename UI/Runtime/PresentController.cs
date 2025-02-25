using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ModulesGT.UI
{
    public class PresentController
    {
        private readonly Dictionary<Type, BasePresenter> _presenters;
        private readonly Transform _holderTransform;
        private readonly Stack<BasePresenter> _activePresenters = new Stack<BasePresenter>();

        protected PresentController(BasePresenter[] basePresenters, Transform holderTransform)
        {
            _holderTransform = holderTransform;
            _presenters = new Dictionary<Type, BasePresenter>();
            foreach (var presenter in basePresenters)
            {
                _presenters.Add(presenter.GetType(), presenter);
            }
        }

        public T Show<T>(IPresenterData data = null, Action onShow = null) where T : BasePresenter
        {
            var presenter = InstantiatePresenter<T>();
            presenter.Show(data, onShow);
            _activePresenters.Push(presenter);
            return presenter;
        }

        
        public void CloseCurrent(Action onClose = null)
        {
            if (_activePresenters.Count == 0)
            {
                Debug.LogWarning("No active presenters to close.");
                return;
            }

            var presenter = _activePresenters.Pop();
            presenter.Close(onClose);
        }
        
        private T InstantiatePresenter<T>() where T : BasePresenter
        {
            if (!_presenters.ContainsKey(typeof(T)))
            {
                throw new KeyNotFoundException($"{typeof(T)} not found in Presenters dictionary.");
            }

            BasePresenter presenterPrefab = _presenters[typeof(T)];
            if (presenterPrefab == null)
            {
                throw new InvalidOperationException($"Presenter prefab for type {typeof(T)} is null.");
            }

            BasePresenter presenter = Object.Instantiate(presenterPrefab, _holderTransform);
            return (T)presenter;
        }
    }
}