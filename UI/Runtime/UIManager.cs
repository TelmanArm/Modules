using UnityEngine;

namespace ModulesGT.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Popup Configuration")]
        [Header("Views")]
        [SerializeField] private RectTransform viewHolder;
        [SerializeField] private BasePresenter[] views;
        [Header("Popups")]
        [SerializeField] private RectTransform popupHolder;
        [SerializeField] private BasePresenter[] popups;
      

        public PopupController PopupController { get; private set; }
        public ViewController ViewController { get; private set; }

        private void Awake()
        {
            if (popupHolder == null || viewHolder == null)
            {
                Debug.LogError("PopupHolder or ViewHolder is not assigned.");
                return;
            }

            popupHolder.FitInSafeArea();
            viewHolder.FitInSafeArea();

            PopupController = new PopupController(popups, popupHolder);
            ViewController = new ViewController(views, viewHolder);
        }
    }
}