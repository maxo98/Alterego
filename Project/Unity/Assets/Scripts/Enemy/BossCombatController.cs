using System;
using Script.ThirdPersonScripts;
using ThirdPersonScripts;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Enemy
{
    public class BossCombatController : MonoBehaviour
    {
       
        [SerializeField] private int maxCombo = 3;
        [SerializeField] private Animator animator;

        [SerializeField] private CharacterAutoAttacks autoAttacks;
        public bool IsAttacking { get; private set; }
        private static readonly int AnimationPlaying = Animator.StringToHash("AnimationPlaying");
        private bool _lightAttackIntent;
        private bool _heavyAttackIntent;

        public void LightEnemyAttack()
        {
            _lightAttackIntent = true;
        }
        
        public void HeavyEnemyAttack()
        {
            _heavyAttackIntent = true;
        }

        private void Start()
        {
            var animationFinishedStream = animator.GetBehaviour<ObservableStateMachineTrigger>()
                .OnStateEnterAsObservable();
            
            var readyToReceiveCombo = new ReactiveProperty<bool>();

            var leftMovesToComplete = new ReactiveProperty<int>(0);
            var pendingMoves = new ReactiveProperty<int>(0);

            var lastAnimationRegistered = new ReactiveProperty<AnimationType?>(null);

            var animationTypeStream = Observable.EveryUpdate()
                .Where(_ => _lightAttackIntent || _heavyAttackIntent)
                .Where(_ => readyToReceiveCombo.Value)
                .Select(_ =>
                {
                    
                    if (_lightAttackIntent)
                    {
                        IsAttacking = true;
                        _lightAttackIntent = false;
                        _heavyAttackIntent = false;
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

                    if (_heavyAttackIntent)
                    {
                        IsAttacking = true;
                        _lightAttackIntent = false;
                        _heavyAttackIntent = false;
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
                    }
                    
                    throw new Exception("This should not happen either");


                });
                
            var animationStream =
                animationTypeStream
                    // .Do(_ => moveCompletedSubject.OnNext(Unit.Default))
                    .Do(last => lastAnimationRegistered.Value = last)
                    .Do(_ =>
                    {
                        pendingMoves.Value += 1;
                        autoAttacks.Activate(pendingMoves.Value);
                    })
                    .Do(_ => leftMovesToComplete.Value += 1);

            var resetAnimationStream = animationFinishedStream.AsUnitObservable()
                .Do(_ => animator.SetInteger(AnimationPlaying, 0));

            var animationOrderStream = animationStream
                .Zip(resetAnimationStream.StartWith(Unit.Default), (type, unit) => type);

            pendingMoves
                .Where(_ => pendingMoves.Value == maxCombo)
                .Subscribe(_ => readyToReceiveCombo.Value = false)
                .AddTo(this);

            resetAnimationStream
                .Subscribe(_ =>
                {
                    leftMovesToComplete.Value -= 1;
                })
                .AddTo(this);

            leftMovesToComplete
                .Where(_ => leftMovesToComplete.Value == 0)
                .Subscribe(_ =>
                {
                    pendingMoves.Value = 0;
                    readyToReceiveCombo.Value = true;
                    lastAnimationRegistered.Value = null;
                    IsAttacking = false;
                })
                .AddTo(this);

            animationOrderStream.Subscribe(anim =>
                {
                    animator.SetInteger(AnimationPlaying, (int) anim);
                    //Debug.Log($"{Enum.GetName(typeof(AnimationType), anim)}");
                })
                .AddTo(this);
        }
    }
}