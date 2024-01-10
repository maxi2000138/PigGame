using System;
using UnityEngine;

public class ViewPigUnit : MonoView, IDisposable
{
    public Vector3 Size => Transform.localScale;

    [SerializeField] private AnimatorViewPigUnit _animator;
    

    public void Dispose()
    {
        _animator.CancelAnimation();
    }
}
