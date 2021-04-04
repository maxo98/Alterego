using UnityEngine;

namespace ThirdPersonScripts
{
    public class CharacterAutoAttacks : MonoBehaviour
    {
        [SerializeField] private GameObject player;

        [SerializeField] private float autoAttackBaseDamage;
        [SerializeField] private float attackDuration;
        
        private bool _activated;
        private float _currentAttackDuration;
        private float _attackDamage;
        private void OnTriggerStay(Collider other)
        {
            if (!_activated) return;
            Debug.Log("SLASH");
            var enemy = other.gameObject;
            if (!enemy.CompareTag("enemy")) return;
            var enemyRb = enemy.GetComponent<Rigidbody>();
            var direction = player.transform.position - other.transform.position;
            direction.y = 0;
            AddDamage(enemy);
            enemyRb.AddForce(direction.normalized * -300, ForceMode.Force);
        }

        private void Update()
        {
            if (_activated)
            {
                if (_currentAttackDuration <= 0)
                {
                    _activated = false;
                }
                else
                {
                    _currentAttackDuration -= Time.deltaTime;
                }
            }
        }

        public void Activate(int comboHit)
        {
            _attackDamage = autoAttackBaseDamage * comboHit;
            _activated = true;
            _currentAttackDuration = attackDuration;
        }

        private void AddDamage(GameObject go)
        {
            go.GetComponent<EnemyHealth>().DoDamage(_attackDamage);
        }
        
    }
}
