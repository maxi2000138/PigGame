using System;
using UnityEngine;

public class ViewPigUnit : MonoView, IDisposable
{
    [SerializeField] private AnimatorViewPigUnit _animator;
    public void Dispose()
    {
        _animator.CancelAnimation();
    }
}
