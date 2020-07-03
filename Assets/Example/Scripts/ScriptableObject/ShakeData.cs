using UnityEngine;

namespace DottweenExample
{
    [CreateAssetMenu(fileName = "Shakes Data",
        menuName = "Data/Shakes Data")]
    public sealed class ShakeData : ScriptableObject
    {
        public float Duration;
        public float Strength;
        public int Vibrato;

        [Range(0.0f, 90.0f)]
        public float Randomness;
    }
}
