using System;
using UnityEngine;

namespace DottweenExample
{
    [Serializable]
    public sealed class FadeParams: TweenParams
    {
        [Range(0.0f, 1.0f)] public float Target;
    }
}
