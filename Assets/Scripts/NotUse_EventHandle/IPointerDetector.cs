using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyEventSystems
{
    public enum MyEventType
    {
        None = 0,
        Enter = 1,
        Exit = 2,
        Down = 3,
        Up = 4
    }

    public interface IPointerDetector : IMyPointerEnterHandler, IMyPointerExitHandler,
                                       IMyPointerDownHandler, IMyPointerUpHandler
    {
        void OnSelected();
    }

}