using ThirdPersonScripts;
using UnityEngine;

namespace Skills
{
    public class DefaultSkill : Skill
    {
        public override SkillsEnum GetSkillName()
        {
            return SkillsEnum.DefaultSKill;
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
