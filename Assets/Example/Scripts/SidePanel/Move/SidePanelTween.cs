using DG.Tweening;
using UnityEngine;

namespace DottweenExample
{
    public sealed class SidePanelTween : ISidePanelElementTween
    {
        private static readonly Vector2 OutAnchorMin = new Vector2(-1.0f, 0.0f);
        private static readonly Vector2 InAnchorMin = new Vector2(0.0f, 0.0f);
        private static readonly Vector2 OutAnchorMax = new Vector2(0.0f, 1.0f);
        private static readonly Vector2 InAnchorMax = new Vector2(1.0f, 1.0f);
        private readonly RectTransform moveRoot;


        public SidePanelTween(RectTransform moveRoot)
        {
            this.moveRoot = moveRoot;
        }


        public void GoToEnd(MoveMode mode)
        {
            switch (mode)
            {
                case MoveMode.Show:
                    moveRoot.anchorMin = InAnchorMin;
                    moveRoot.anchorMax = InAnchorMax;
                    break;
                case MoveMode.Hide:
                    moveRoot.anchorMin = OutAnchorMin;
                    moveRoot.anchorMax = OutAnchorMax;
                    break;
                default:
                    break;
            }
        }


        public Sequence Move(MoveMode mode, float timeScale)
        {
            Vector2 anchorMin = Vector2.zero;
            Vector2 anchorMax = Vector2.zero;
            switch (mode)
            {
                case MoveMode.Show:
                    anchorMin = InAnchorMin;
                    anchorMax = InAnchorMax;
                    break;
                case MoveMode.Hide:
                    anchorMin = OutAnchorMin;
                    anchorMax = OutAnchorMax;
                    break;
                default:
                    break;
            }

            const float totalMoveDuration = 0.5f;
            const Ease moveEase = Ease.InOutBack;
            return DOTween.Sequence()
                .Append(moveRoot.DOAnchorMin(anchorMin, totalMoveDuration * timeScale).SetEase(moveEase))
                .Join(moveRoot.DOAnchorMax(anchorMax, totalMoveDuration * timeScale).SetEase(moveEase));
        }
    }
}