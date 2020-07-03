using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DottweenExample
{
    public sealed class SidePanelMoveBehaviour : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private RectTransform _sidePanel;
        [SerializeField] private GameObject _touchBlocker;
        [SerializeField] private Button[] _hideSidePanelButtons;

        private ISidePanelElementTween[] _elementTweens;
        private Sequence _moveSequence;

        private void Start()
        {
            _elementTweens.ForEach(t => t.GoToEnd(MoveMode.Hide));
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _elementTweens = new ISidePanelElementTween[]
            {
                new SidePanelTween(_sidePanel),
            };

            foreach (Button button in _hideSidePanelButtons)
            {
                button.onClick.AddListener(HideSidePanel_OnClick);
            }
        }


        private void OnDisable()
        {
            foreach (Button button in _hideSidePanelButtons)
            {
                button.onClick.RemoveListener(HideSidePanel_OnClick);
            }
        }

        private Sequence Move(MoveMode mode)
        {
            _touchBlocker.SetActive(true);

            float timeScale = 1.0f;
            if (_moveSequence != null)
            {
                timeScale = _moveSequence.position / _moveSequence.Duration();
                _moveSequence.Kill();
            }

            _moveSequence = DOTween.Sequence();
            _elementTweens.ForEach(t => _moveSequence.Join(t.Move(mode, timeScale)));
            _moveSequence.AppendCallback(() =>
            {
                _touchBlocker.SetActive(false);
                _moveSequence = null;
            });

            return _moveSequence;
        }

        private void HideSidePanel_OnClick()
        {
            Move(MoveMode.Hide).AppendCallback(() =>
            {
                gameObject.SetActive(false);
                _text.text = "New text New text New text ";
            });
        }

        public void ShowSidePanel_OnClick()
        {
            gameObject.SetActive(true);
            _elementTweens.ForEach(t => t.GoToEnd(MoveMode.Hide));
            Move(MoveMode.Show).AppendCallback(() => { _text.DOText("panoramik panoramik panoramik", 1.0f); });
        }
    }
}
