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
        
        [SerializeField] private List<Skill> skillList = new List<Skill>();

        private readonly Dictionary<SkillsEnum, Skill> _skillDictionary = new Dictionary<SkillsEnum, Skill>();

        public void Start()
        {
            foreach (var skill in skillList)
            {
                _skillDictionary.Add(skill.GetSkillName(), skill);
            }
        }

        public Skill PlayerUnlockNewSkill(SkillsEnum skillName)
        {
            return _skillDictionary[skillName];
        }
    }
}
