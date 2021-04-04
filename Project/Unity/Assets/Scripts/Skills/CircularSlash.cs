using ThirdPersonScripts;
using UnityEngine;

namespace Skills
{
    public class CircularSlash : Skill
    {

        public override SkillsEnum GetSkillName()
        {
            return SkillsEnum.CircularSlash;
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