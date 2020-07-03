using System;
using DG.Tweening;
using UnityEngine;


namespace DottweenExample
{
    public sealed class TweenMoveBehaviour : MonoBehaviour
    {
        [SerializeField] private MoveParams _tweenParamsShow;
        [SerializeField] private MoveParams _tweenParamsHide;
        private RectTransform _rectTransform;
        private Tweener _tweener;
        
        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
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
        
        private void Move(MoveParams tweenParams)
        {
            _tweener?.Kill();
            _tweener = _rectTransform.DOAnchorPos(tweenParams.Target,
                tweenParams.Duration).SetDelay(tweenParams.Delay);
            _tweener.SetEase(tweenParams.Ease);
        }
    }
}

