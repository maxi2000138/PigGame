using System.Collections.Generic;
using System.Linq;
using App.Scripts.Infrastructure.SharedViews.Animator;
using UnityEngine;

public class AnimatorViewPigUnit : MonoBehaviour
{
    private readonly List<AnimationTweenBase> _animations = new();

    public bool IsSomeAnimating => IsSomeAnimation();
    public bool IsMoveAnimating => false;
    
    private bool IsSomeAnimation()
    {
        return _animations.Any(x => x.IsAnimating);
    }
    
    public void CancelAnimation()
    {
        foreach (var animationTween in _animations)
            animationTween.CancelAnimation();
    }
}
