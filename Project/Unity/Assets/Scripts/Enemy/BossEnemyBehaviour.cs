using System;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

namespace Enemy
{
    public class BossEnemyBehaviour : EnemyBehaviour
    {
        [SerializeField] private float attackCooldown;
        [SerializeField] private BossCombatController bossCombatController;
        
        private GameObject _target;
        private bool _attackIntent;
        private float _currentAttackDuration;
        private float _currentAttackCooldown;
        private Random _rand = new Random();
        
        private void Update()
        {
            if (_attackIntent)
            {
                if (_currentAttackCooldown <= 0)
                {
                    //Debug.Log("enemy target : " + _target.name);
                    _currentAttackCooldown = attackCooldown;
                    //Debug.Log("Enemy Attack");
                    Attack();
                }
                else
                {
                    _currentAttackCooldown -= Time.deltaTime;
                }
            }
        }

        protected override void Attack()
        {
            if (_rand.Next(0, 1) == 1)
            {
                bossCombatController.HeavyEnemyAttack();
            }
            else
            {
                bossCombatController.LightEnemyAttack();
            }
        }
        
    }
}
