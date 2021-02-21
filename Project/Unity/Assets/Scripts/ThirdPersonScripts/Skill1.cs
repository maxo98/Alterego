using UnityEngine;

namespace Script.ThirdPersonScripts
{
    public class Skill1 : CharacterSkill
    {
        public override void OnCollisionStay(Collision other)
        {
            var enemy = other.gameObject;
            if (ActionUsed && enemy.CompareTag($"enemy"))
            {
                Debug.Log("enemy touched");
            }
        }
    }
}
