using ThirdPersonScripts;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float attackBaseDamage;
        [SerializeField] private float attackCooldown;
        
        private float _currentAttackDuration;
        private float _currentAttackCooldown;
        private void OnTriggerEnter(Collider other)
        {
            if (_currentAttackCooldown <= 0)
            {
                _currentAttackCooldown = attackCooldown;
                Debug.Log("SLASH");
                var enemy = other.gameObject;
                if (!enemy.CompareTag("Player")) return;
                AddDamage(enemy);
            }
            else
            {
                _currentAttackCooldown -= Time.deltaTime;
            }
        }

        private void AddDamage(GameObject go)
        {
            go.GetComponent<CharacterStatistic>().PlayerDamaged(attackBaseDamage);
        }
    }
}
