using System.Collections;
using UnityEngine;

namespace DottweenExample
{
    public sealed class ScaleBehaviour : MonoBehaviour
    {
        [SerializeField] private TweenScaleBehaviour[] _moveButtonBehaviours;
        private bool _isShow = true;

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                Hide();
                yield return new WaitForSeconds(0.5f);
                Show();
                yield return new WaitForSeconds(0.5f);
            }
        }

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
    }
}
