
using ThirdPersonScripts;
using UnityEngine;

namespace Skills
{
    public class SwordThrowing : Skill
    {

        [SerializeField] private float skillDamage;

        public override SkillsEnum GetSkillName()
        {
            return SkillsEnum.SwordThrowing;
        }

        protected override void Action(GameObject enemy)
        {
            enemy.GetComponent<EnemyHealth>().DoDamage(skillDamage);
        }

        protected override void StartAnimation()
        {
            throw new System.NotImplementedException();
        }

    }
}