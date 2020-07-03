using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public sealed class ButtonFlareBehaviour : MonoBehaviour
{
    [SerializeField] private float _interval;

    [Space]
    [SerializeField] private Image _highlightImage;

    [Space]
    [SerializeField] private float _upFadeDuration;
    [SerializeField] private float _downFadeDuration;
    [SerializeField] private float _moveDuration;
    [SerializeField][Range(0.0f, 1.0f)] private float _minAnchorX;

    private Sequence _highlightSequence;

    private void OnEnable()
    {
        Reset();

        _highlightSequence = DOTween.Sequence();
        _highlightSequence.Insert(0.0f, _highlightImage.DOFade(1.0f, _upFadeDuration));
        _highlightSequence.Insert(0.0f, _highlightImage.rectTransform.DOAnchorMin(new Vector2(_minAnchorX, 0.0f), _moveDuration));
        _highlightSequence.Insert(0.0f, _highlightImage.rectTransform.DOAnchorMax(Vector2.one, _moveDuration));
        _highlightSequence.Insert(_upFadeDuration, _highlightImage.DOFade(0.0f, _downFadeDuration));
        _highlightSequence.AppendCallback(Reset);
        _highlightSequence.AppendInterval(_interval);
        _highlightSequence.SetLoops(-1);
        _highlightSequence.Play();
    }

    private void OnDisable()
    {
        _highlightSequence.Kill(true);
    }

    private void Reset()
    {
        _highlightImage.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        _highlightImage.rectTransform.anchoredPosition = new Vector2(0.0f, _highlightImage.rectTransform.anchoredPosition.y);
        _highlightImage.rectTransform.anchorMin = Vector2.zero;
        _highlightImage.rectTransform.anchorMax = Vector2.up;
    }
}