using ThirdPersonScripts;
using UnityEngine;

namespace Enemy
{
    public class EnemyAutoAttacks : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private Collider collider;
        [SerializeField] private float autoAttackBaseDamage;
        [SerializeField] private float attackDuration;
        
        private bool _activated;
        private float _currentAttackDuration;
        private float _attackDamage;
        private void OnTriggerEnter(Collider other)
        {
            if (!_activated) return;
            var enemy = other.gameObject;
            if (!enemy.CompareTag("Player")) return;
            AddDamage(enemy);
        }

        private void Update()
        {
            if (!_activated) return;
            if (_currentAttackDuration <= 0)
            {
                _activated = false;
                collider.enabled = false;
            }
            else
            {
                _currentAttackDuration -= Time.deltaTime;
            }
        }

        public void Activate(int comboHit)
        {
            _attackDamage = autoAttackBaseDamage * comboHit;
            collider.enabled = true;
            _activated = true;
            _currentAttackDuration = attackDuration;
        }

        private void AddDamage(GameObject go)
        {
            go.GetComponentInParent<CharacterStatistic>().PlayerDamaged(_attackDamage);
        }
        
    }
}