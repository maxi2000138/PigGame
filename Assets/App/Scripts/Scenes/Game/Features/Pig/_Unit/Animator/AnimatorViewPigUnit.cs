using System.Collections.Generic;
using App.Scripts.Infrastructure.SharedViews.Animator;
using UnityEngine;

public class AnimatorViewPigUnit : MonoBehaviour
{
    [SerializeField] private Animator _pigAnimator;
    [SerializeField] private AnimatorViewMoveTo _animatorViewMoveTo;
    
    private readonly List<AnimationTweenBase> _animations = new();
    
    private static readonly int Jump = Animator.StringToHash("Jump");
    
    public bool IsSomeAnimating => IsAnimating();
    public bool IsJumpAnimating => IsAnimating(Jump);
    
    
    public void AnimateJump(Vector3 to)
    {
        _pigAnimator.Play(Jump);
        _animatorViewMoveTo.AnimateMoveTo(to);
    }
    
    public void CancelAnimations()
    {
        _pigAnimator.enabled = false;
    }

    private bool IsAnimating(int hash) => _pigAnimator.GetCurrentAnimatorStateInfo(0).shortNameHash == hash;
    private bool IsAnimating() => _pigAnimator.GetCurrentAnimatorStateInfo(0).shortNameHash == 0;
}
