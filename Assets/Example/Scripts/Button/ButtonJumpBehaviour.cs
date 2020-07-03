using System;
using DG.Tweening;
using UnityEngine;

namespace DottweenExample
{
    public sealed class ButtonJumpBehaviour : MonoBehaviour
    {
        [SerializeField] private float _interval;

        [Space]
        [SerializeField]
        private RectTransform _rectTransform;

        private Sequence _sequence;

        private void Start()
        {
            _sequence = DOTween.Sequence();
            _sequence.Append(_rectTransform.DOJumpAnchorPos(new Vector2(0.0f, 0.0f), 15.0f, 1, 1.0f));
            _sequence.AppendInterval(_interval);
            _sequence.SetLoops(-1);
        }

        private void OnEnable()
        {
            _sequence.Play();
        }

        private void OnDisable()
        {
            _sequence.Pause();
        }

        private void OnDestroy()
        {
            _sequence = null;
        }
    }
}
