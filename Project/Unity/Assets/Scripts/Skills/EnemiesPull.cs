using ThirdPersonScripts;
using UnityEngine;

namespace Skills
{
    public class EnemiesPull : Skill
    {
        public override SkillsEnum GetSkillName()
        {
            return SkillsEnum.EnemiesPull;
        }

        protected override void Action(GameObject enemy)
        {
        }

        protected override void StartAnimation()
        {
            throw new System.NotImplementedException();
        }
    }
}