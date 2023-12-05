
using System;
using UnityEngine.Events;
using UnityEngine.UI;

public interface IButton
{
    void SetOnClick(Action<float> action);
    void SetText(string text);
    void SetValue(float value);
}
