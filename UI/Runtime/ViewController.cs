using UnityEngine;

namespace ModulesGT.UI
{
    public class ViewController : PresentController
    {
        public ViewController(BasePresenter[] basePresenters, Transform holderTransform) : base(basePresenters, holderTransform)
        {
        }
    }
}
