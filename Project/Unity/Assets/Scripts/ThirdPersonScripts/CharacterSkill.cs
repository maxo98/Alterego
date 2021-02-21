using System;
using UnityEngine;
using UnityEngine.InputSystem.Users;

namespace Script.ThirdPersonScripts
{
    public class CharacterSkill : MonoBehaviour
    {
        [SerializeField] private BoxCollider rangeCollider;

        protected bool ActionUsed = false;

        public void Use()
        {
            ActionUsed = true;
        }

        public virtual void OnCollisionStay(Collision other)
        {
            Debug.Log("skill used");
        }
        
    }
}
