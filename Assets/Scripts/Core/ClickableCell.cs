using System;
using UnityEngine;

public class ClickableCell : MonoBehaviour, IClickable
{
    public event Action OnClicked;

    void IClickable.Click()
    {
            OnClicked?.Invoke();
    }
}
