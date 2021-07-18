using UnityEngine;

namespace ThirdPersonScripts
{
    public class CharacterAutoAttacks : MonoBehaviour
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
            if (!enemy.CompareTag("enemy")) return;
            Debug.Log("SLASH");
            var enemyRb = enemy.GetComponent<Rigidbody>();
            var direction = player.transform.position - other.transform.position;
            direction.y = 0;
            AddDamage(enemy);
            enemyRb.AddForce(direction.normalized * -100, ForceMode.Force);
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
            
            go.GetComponent<EnemyHealth>().DoDamage(_attackDamage);
        }
        
    }
}
