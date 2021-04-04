using Skills;
using UnityEngine;

namespace ThirdPersonScripts
{
    public class ThirdPersonSkillsController : MonoBehaviour
    {
        [SerializeField] private Skill action1;
        [SerializeField] private Skill action2;
        [SerializeField] private Skill action3;
        
        public void OnCharacterAction1()
        {
            Debug.Log("action1 used" + action1.GetType());
            action1.ActivateSkill();
        }

        public void ChangeAction1(Skill skill)
        {
            action1 = skill;
        }
        
        public void ChangeAction2(Skill skill)
        {
            action2 = skill;
        }
        public void ChangeAction3(Skill skill)
        {
            action3 = skill;
        }
    }
}