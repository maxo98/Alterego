using ThirdPersonScripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Skills
{
    public abstract class Skill : MonoBehaviour
    {

        public abstract SkillsEnum GetSkillName();
        
        public void OnCollisionStay(Collision other)
        {
            var enemy = other.gameObject;
            if (enemy.CompareTag($"enemy"))
            {
                Debug.Log("enemy touched");
            }
        }
    }
}
