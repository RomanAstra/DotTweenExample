using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DottweenExample
{
    public sealed class MessageBoxBehaviour : MonoBehaviour
    {
        [SerializeField] private Button _buttonHide;

        [SerializeField] private GameObject _root;
        [SerializeField] private Transform _message;
        [SerializeField] private Image _background;
        [SerializeField] private float _duration = 0.5f;

        private void Start()
        {
            Hide(0);
        }

        private void OnEnable()
        {
            _buttonHide.onClick.AddListener(ButtonHide_OnClick);
        }

        private void OnDisable()
        {
            _buttonHide.onClick.AddListener(ButtonHide_OnClick);
        }

        private void Show()
        {
            _root.SetActive(true);
            Sequence sequence = DOTween.Sequence();
            sequence.Insert(0.0f, _background.DOFade(0.5f, _duration));
            sequence.Insert(0.0f, _message.DOScale(Vector3.one, _duration));
            sequence.OnComplete(() =>
            {
                sequence = null;
            });
        }

        private void Hide(float duration)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(_message.DOScale(Vector3.zero, duration));
            sequence.Append(_background.DOFade(0.0f, duration));
            sequence.OnComplete(() =>
            {
                sequence = null;
                _root.SetActive(false);
            });
        }

        private void ButtonHide_OnClick()
        {
            Hide(_duration);
        }

        public void ButtonShow_OnClick()
        {
            Show();
        }
    }
}
