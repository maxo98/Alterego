using System;
using ThirdPersonScripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Skills
{
    public abstract class Skill : MonoBehaviour
    {
        [SerializeField] private float attackDuration;
        
        protected bool Used;
        private float _currentAttackDuration;
        
        public abstract SkillsEnum GetSkillName();

        public void OnTriggerStay(Collider other)
        {
            if (!Used) return;
            var enemy = other.gameObject;
            if (!enemy.CompareTag("enemy")) return;
            Debug.Log("enemy in range of the skill");
            Action(enemy);
            Used = false;
        }
        
        private void Update()
        {
            if (!Used) return;
            if (_currentAttackDuration <= 0)
            {
                Used = false;
            }
            else
            {
                _currentAttackDuration -= Time.deltaTime;
            }
        }

        public void ActivateSkill()
        {
            _currentAttackDuration = attackDuration;
            Used = true;
            //StartAnimation();
        }

        protected abstract void Action(GameObject enemy);

        protected abstract void StartAnimation();
    }
}
