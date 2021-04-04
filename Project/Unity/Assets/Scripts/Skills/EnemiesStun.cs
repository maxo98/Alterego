using ThirdPersonScripts;
using UnityEngine;

namespace Skills
{
    public class EnemiesStun : Skill
    {
        public override SkillsEnum GetSkillName()
        {
            return SkillsEnum.EnemiesStun;
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