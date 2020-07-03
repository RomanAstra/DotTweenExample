using UnityEngine;

namespace DottweenExample
{
    [CreateAssetMenu(fileName = "KeyCode Data",
        menuName = "Data/KeyCode Data")]
    public sealed class KeyCodeData : ScriptableObject
    {
        public KeyCode KeyCodeHide = KeyCode.Escape;
        public KeyCode KeyCodeScale = KeyCode.Tab;
        public KeyCode KeyCodeFade = KeyCode.LeftShift;
    }
}
