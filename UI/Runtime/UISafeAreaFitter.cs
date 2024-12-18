using UnityEngine;

namespace ModulesGT.UI
{
    public static class UISafeAreaFitter
    {
        public static void FitInSafeArea(this RectTransform trans)
        {
            Rect safeAreaRect = Screen.safeArea;
            
            Vector2 anchorMin = safeAreaRect.position;
            Vector2 anchorMax = safeAreaRect.position + safeAreaRect.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;
            trans.anchorMax = anchorMax;
        }
    }
}
