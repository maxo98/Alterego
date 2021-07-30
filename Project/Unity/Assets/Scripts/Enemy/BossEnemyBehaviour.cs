using System;
using ThirdPersonScripts;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

namespace Enemy
{
    public class BossEnemyBehaviour : EnemyBehaviour
    {
        [SerializeField] private float attackCooldown;
        [SerializeField] private float attackRange;
        [SerializeField] private float autoAttackBaseDamage;
        [SerializeField] private BossCombatController bossCombatController;
        [SerializeField] private EnemyAutoAttacks enemyAutoAttacks;

        private float _currentAttackCooldown;
        private Random _rand = new Random();

        protected override void Attack()
        {
            if (_currentAttackCooldown <= 0  && Vector3.Distance(Player.transform.position, gameObject.transform.position) < attackRange)
            {
                enemyAutoAttacks.Activate(1);
                //Debug.Log("enemy target : " + _target.name);
                _currentAttackCooldown = attackCooldown;
                //Debug.Log("Enemy Attack");
                var combo = _rand.Next(1, 3);
                if (combo == 1)
                {
                    bossCombatController.HeavyEnemyAttack();
                }
                else
                {
                    bossCombatController.LightEnemyAttack();
                }
                Player.GetComponentInParent<CharacterStatistic>().PlayerDamaged(autoAttackBaseDamage * combo);
            }
            else
            {
                _currentAttackCooldown -= Time.deltaTime;
            }
            
        }
        
    }
}
