using System;
using App.Scripts.Infrastructure.SharedViews.Animator;
using DG.Tweening;
using UnityEngine;

public class AnimatorViewMoveTo : AnimationTweenBase
{
    [SerializeField] private Transform container;

    [SerializeField] private AnimatorConfig config;

    public void AnimateMoveTo(Vector3 to)
    {
        CancelAnimation();

        var animationMove = DOTween.Sequence();
        
        animationMove.Append(container.DOMove(to, config.durationMove).SetEase(Ease.InSine));

        StartAnimation(animationMove);
    }

    [Serializable]
    public class AnimatorConfig
    {
        public Ease MoveEase;
        public float durationMove;
    }    
}
