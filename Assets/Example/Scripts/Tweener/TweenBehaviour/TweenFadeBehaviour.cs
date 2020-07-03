using System;
using DG.Tweening;
using UnityEngine;

namespace DottweenExample
{
    public sealed class TweenFadeBehaviour : MonoBehaviour
    {
        [SerializeField] private FadeParams _tweenParamsShow;
        [SerializeField] private FadeParams _tweenParamsHide;
        private CanvasGroup _canvasGroup;
        private Tweener _tweener;
        
        private void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        
        private void OnDisable()
        {
            _tweener.Kill();
        }

        public void TweenByState(MoveMode mode)
        {
            switch (mode)
            {
                case MoveMode.Show:
                    Move(_tweenParamsShow);
                    break;
                case MoveMode.Hide:
                    Move(_tweenParamsHide);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode,
                        null);
            }
        }
        
        private void Move(FadeParams tweenParams)
        {
            _tweener?.Kill();
            _tweener = _canvasGroup.DOFade(tweenParams.Target, tweenParams.Duration)
                .SetDelay(tweenParams.Delay)
                .OnComplete(() => _canvasGroup.interactable = (tweenParams.Target > 0.0f));
            _tweener.SetEase(tweenParams.Ease);
        }
    }
}
