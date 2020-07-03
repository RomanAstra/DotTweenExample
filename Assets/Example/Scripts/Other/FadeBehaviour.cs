using UnityEngine;

namespace DottweenExample
{
    public sealed class FadeBehaviour : MonoBehaviour
    {
        [SerializeField] private TweenFadeBehaviour[] _moveButtonBehaviours;
        [SerializeField] private KeyCodeData _codeData;
        private bool _isShow = true;

        private void Show()
        {
            foreach (var tween in _moveButtonBehaviours)
            {
                tween.TweenByState(MoveMode.Show);
            }
        }

        private void Hide()
        {
            foreach (var tween in _moveButtonBehaviours)
            {
                tween.TweenByState(MoveMode.Hide);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(_codeData.KeyCodeFade))
            {
                _isShow = !_isShow;
                if (_isShow)
                {
                    Show();
                }
                else
                {
                    Hide();
                }
            }
        }
    }
}
