using System;
using System.Collections.Generic;
using Skills;
using UnityEngine;

namespace ThirdPersonScripts
{
    public enum SkillsEnum {SwordThrowing, LunarSlash, CircularSlash, EnemiesPull, EnemiesFlash, EnemiesStun, DefaultSKill}
    
    public class SkillsManager : MonoBehaviour
    {
        private SkillsEnum _skills;

        [SerializeField] private ThirdPersonSkillsController skillsController;
        [SerializeField] private List<Skill> skillList = new List<Skill>();

        private readonly Dictionary<SkillsEnum, Skill> _skillDictionary = new Dictionary<SkillsEnum, Skill>();

        public void Start()
        {
            foreach (var skill in skillList)
            {
                _skillDictionary.Add(skill.GetSkillName(), skill);
            }
        }

        public void PlayerUnlockNewSkill(SkillsEnum skillName, int skillSlot)
        {
            switch (skillSlot)
            {
                case 1: 
                    skillsController.ChangeAction1(_skillDictionary[skillName]);
                    break;
                case 2:
                    skillsController.ChangeAction2(_skillDictionary[skillName]);
                    break;
                case 3:
                    skillsController.ChangeAction3(_skillDictionary[skillName]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(skillSlot), skillSlot, null);
            }
             
        }
    }
}
