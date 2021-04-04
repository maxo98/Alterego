using ThirdPersonScripts;
using UnityEngine;

namespace Skills
{
    public class LunarSlash : Skill
    {
        public override SkillsEnum GetSkillName()
        {
            return SkillsEnum.LunarSlash;
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