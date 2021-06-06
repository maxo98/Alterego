using System;
using ThirdPersonScripts;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float attackBaseDamage;
        [SerializeField] private float attackCooldown;

        private GameObject _target;
        private bool _attackIntent;
        private float _currentAttackDuration;
        private float _currentAttackCooldown;

        private void Start()
        {
            _currentAttackCooldown = attackCooldown;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            //Debug.Log("player in range");
            _target = other.gameObject;
            _attackIntent = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.Equals(_target)) return;
            //Debug.Log("player out range");
            _attackIntent = false;
            _currentAttackCooldown = attackCooldown;
        }

        private void Update()
        {
            if (_attackIntent)
            {
                if (_currentAttackCooldown <= 0)
                {
                    //Debug.Log("enemy target : " + _target.name);
                    _currentAttackCooldown = attackCooldown;
                    //Debug.Log("Enemy Attack");
                    AddDamage(_target);
                }
                else
                {
                    _currentAttackCooldown -= Time.deltaTime;
                }
            }
        }

        private void AddDamage(GameObject go)
        {
            go.GetComponentInParent<CharacterStatistic>().PlayerDamaged(attackBaseDamage);
        }
    }
}
