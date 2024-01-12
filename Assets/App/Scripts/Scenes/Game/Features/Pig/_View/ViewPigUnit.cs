using System;
using UnityEngine;

public class ViewPigUnit : MonoView, IDisposable
{ 
    public Vector3 Size => Transform.localScale;

    [SerializeField] private AnimatorViewPigUnit _animator;

    
    public void AnimateJump(Vector3 to)
    {
        Transform.LookAt(to);
        _animator.AnimateJump(to);
    }

    public void Dispose()
    {
        _animator.CancelAnimations();
    }
}
