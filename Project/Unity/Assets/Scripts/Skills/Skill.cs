using System;
using ThirdPersonScripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Skills
{
    public abstract class Skill : MonoBehaviour
    {
        [SerializeField] private float attackDuration;
        
        private bool _used;
        private float _currentAttackDuration;
        
        public abstract SkillsEnum GetSkillName();

        public void OnCollisionStay(Collision other)
        {
            if (!_used) return;
            var enemy = other.gameObject;
            if (!enemy.CompareTag("enemy")) return;
            Debug.Log("enemy in range of the skill");
            Action(enemy);
            _used = false;
        }
        
        private void Update()
        {
            if (_used)
            {
                if (_currentAttackDuration <= 0)
                {
                    _used = false;
                }
                else
                {
                    _currentAttackDuration -= Time.deltaTime;
                }
            }
        }

        public void ActivateSkill()
        {
            _used = true;
            _currentAttackDuration = attackDuration;
            //StartAnimation();
        }

        protected abstract void Action(GameObject enemy);

        protected abstract void StartAnimation();
    }
}
