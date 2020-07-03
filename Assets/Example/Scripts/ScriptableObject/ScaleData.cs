using UnityEngine;
using DG.Tweening;

namespace DottweenExample
{
    [CreateAssetMenu(fileName = "Scale Data",
        menuName = "Data/Scale Data")]
    public sealed class ScaleData : ScriptableObject
    {
        public Ease Ease;
        [Range(0f, 5f)] 
        public float Duration;
        public Vector2 Scale;
    }
}
