using Engine.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    private event Action _onMap = null;
    public event Action OnMap
    {
        add
        {
            _onMap -= value;
            _onMap += value;
        }
        remove
        {
            _onMap -= value;
        }
    }

    public void LaunchOnMapOpen()
    {
        _onMap?.Invoke();
    }
}
