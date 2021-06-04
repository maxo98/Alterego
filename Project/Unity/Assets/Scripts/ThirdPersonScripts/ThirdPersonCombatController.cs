using System;
using Script.ThirdPersonScripts;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ThirdPersonScripts
{
    public enum AnimationType
    {
        LightAttack1 = 1,
        LightAttack2 = 2,
        LightAttack3 = 3,
        HeavyAttack1 = 4,
        HeavyAttack2 = 5,
        HeavyAttack3 = 6,
    }

    public class ThirdPersonCombatController : MonoBehaviour
    {
        
        public Animator animator;
        private static readonly int AnimationPlaying = Animator.StringToHash("AnimationPlaying");
        private bool _lightAttackInput = false;
        private bool _heavyAttackInput = false;

        private void Start()
        {
            var animationFinishedStream = animator.GetBehaviour<ObservableStateMachineTrigger>()
                .OnStateEnterAsObservable();
            
            var readyToReceiveCombo = new ReactiveProperty<bool>();

            var leftMovesToComplete = new ReactiveProperty<int>(0);
            var pendingMoves = new ReactiveProperty<int>(0);

            var lastAnimationRegistered = new ReactiveProperty<AnimationType?>(null);

            var animationTypeStream = Observable.EveryUpdate()
                .Where(_ => _lightAttackInput || _heavyAttackInput)
                .Where(_ => readyToReceiveCombo.Value)
                .Select(_ =>
                {
                    if (_lightAttackInput)
                    {
                        switch (lastAnimationRegistered.Value)
                        {
                            case AnimationType.LightAttack1:
                            case AnimationType.HeavyAttack1:
                                return AnimationType.LightAttack2;
                            case AnimationType.LightAttack2:
                            case AnimationType.HeavyAttack2:
                                return AnimationType.LightAttack3;
                            case AnimationType.LightAttack3:
                            case AnimationType.HeavyAttack3:
                                throw new Exception("This should not happen !");
                            case null:
                                return AnimationType.LightAttack1;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }

                    if (!_heavyAttackInput) throw new Exception("This should not happen either");
                    switch (lastAnimationRegistered.Value)
                    {
                        case AnimationType.LightAttack1:
                        case AnimationType.HeavyAttack1:
                            return AnimationType.HeavyAttack2;
                        case AnimationType.LightAttack2:
                        case AnimationType.HeavyAttack2:
                            return AnimationType.HeavyAttack3;
                        case AnimationType.LightAttack3:
                        case AnimationType.HeavyAttack3:
                            throw new Exception("This should not happen !");
                        case null:
                            return AnimationType.HeavyAttack1;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    
                });
                
            var animationStream =
                animationTypeStream
                    // .Do(_ => moveCompletedSubject.OnNext(Unit.Default))
                    .Do(last => lastAnimationRegistered.Value = last)
                    .Do(_ => pendingMoves.Value += 1)
                    .Do(_ => leftMovesToComplete.Value += 1);

            var resetAnimationStream = animationFinishedStream.AsUnitObservable()
                .Do(_ => animator.SetInteger(AnimationPlaying, 0));

            var animationOrderStream = animationStream
                .Zip(resetAnimationStream.StartWith(Unit.Default), (type, unit) => type);

            pendingMoves
                .Where(_ => pendingMoves.Value == 3)
                .Subscribe(_ => readyToReceiveCombo.Value = false)
                .AddTo(this);

            resetAnimationStream
                .Subscribe(_ => leftMovesToComplete.Value -= 1)
                .AddTo(this);

            leftMovesToComplete
                .Where(_ => leftMovesToComplete.Value == 0)
                .Subscribe(_ =>
                {
                    pendingMoves.Value = 0;
                    readyToReceiveCombo.Value = true;
                    lastAnimationRegistered.Value = null;
                })
                .AddTo(this);

            animationOrderStream.Subscribe(anim =>
                {
                    _lightAttackInput = false;
                    _heavyAttackInput = false;
                    animator.SetInteger(AnimationPlaying, (int) anim);
                    Debug.Log($"{Enum.GetName(typeof(AnimationType), anim)}");
                })
                .AddTo(this);
        }
        
        public void OnCharacterLightAttack()
        {
            _lightAttackInput = true;
        }

        public void OnCharacterHeavyAttack()
        {
            _heavyAttackInput = true;
        }
    }
}
