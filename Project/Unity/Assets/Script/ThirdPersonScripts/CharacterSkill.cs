using System;
using UnityEngine;
using UnityEngine.InputSystem.Users;

namespace Script.ThirdPersonScripts
{
    public class CharacterSkill : MonoBehaviour
    {
        [SerializeField] private BoxCollider rangeCollider;

        private bool _actionUsed = false;

        public void Use()
        {
            _actionUsed = true;
        }

        private void OnCollisionStay(Collision other)
        {
            var enemy = other.gameObject;
            if (_actionUsed && enemy.CompareTag($"enemy"))
            {
                Debug.Log("enemy touched");
            }
        }
    }
}
