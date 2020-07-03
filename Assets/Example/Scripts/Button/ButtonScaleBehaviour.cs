using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DottweenExample
{
    [RequireComponent(typeof(Button))]
    public sealed class ButtonScaleBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        [SerializeField] private ScaleData _pointerDownScale;

        [SerializeField] private ScaleData _pointerUpScale;

        void OnDestroy()
        {
            transform.DOKill();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            transform.DOKill();

            transform.DOScale(new Vector3(_pointerDownScale.Scale.x, _pointerDownScale.Scale.y, 
                _pointerDownScale.Scale.x), _pointerDownScale.Duration).SetEase(_pointerDownScale.Ease);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            transform.DOKill();

            transform.DOScale(new Vector3(_pointerUpScale.Scale.x, _pointerUpScale.Scale.y, 
                _pointerUpScale.Scale.x), _pointerUpScale.Duration).SetEase(_pointerUpScale.Ease);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DOKill();

            transform.DOScale(new Vector3(_pointerUpScale.Scale.x, _pointerUpScale.Scale.y, 
                _pointerUpScale.Scale.x), _pointerUpScale.Duration).SetEase(_pointerUpScale.Ease);
        }
    }
}
