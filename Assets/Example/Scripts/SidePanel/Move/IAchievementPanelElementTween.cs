using DG.Tweening;

namespace DottweenExample
{
    public interface ISidePanelElementTween
    {
        void GoToEnd(MoveMode mode);
        Sequence Move(MoveMode mode, float timeScale);
    }
}
