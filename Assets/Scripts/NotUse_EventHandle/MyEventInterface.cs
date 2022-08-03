namespace MyEventSystems
{
    public interface IMyEventSystemHandler
    {
    }

    public interface IMyPointerEnterHandler : IMyEventSystemHandler
    {
        void OnMyPointerEnter();
    }

    public interface IMyPointerExitHandler : IMyEventSystemHandler
    {
        void OnMyPointerExit();
    }

    public interface IMyPointerDownHandler : IMyEventSystemHandler
    {
        void OnMyPointerDown();
    }

    public interface IMyPointerUpHandler : IMyEventSystemHandler
    {
        void OnMyPointerUp();
    }

    public interface IMyPointerClickHandler : IMyEventSystemHandler
    {
        void OnMyPointerClick();
    }
}