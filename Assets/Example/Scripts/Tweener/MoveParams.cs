using System;
using UnityEngine;

namespace DottweenExample
{
    [Serializable]
    public sealed class MoveParams : TweenParams
    {
        public Vector2 Target;
    }
}
