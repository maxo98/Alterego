using System;
using UnityEngine;

namespace ThirdPersonScripts
{
    
    public enum Statistic {Vitality, Defense, Dexterity, Velocity, DamageBonus}
    
    public class CharacterStatistic : MonoBehaviour
    {
        
        private Statistic _statistics;

        [SerializeField] private int vitality;
        [SerializeField] private float vitalityIncrement;
        [SerializeField] private float baseVitality;
        [SerializeField] private int defense;
        [SerializeField] private float defenseIncrement;
        [SerializeField] private float baseDefense;
        [SerializeField] private int dexterity;
        [SerializeField] private float dexterityIncrement;
        [SerializeField] private float baseDexterity;
        [SerializeField] private int velocity;
        [SerializeField] private float velocityIncrement;
        [SerializeField] private int damageBonus;
        [SerializeField] private float damageBonusIncrement;

        private float _playerHealthPoint;

        private void Start()
        {
            _playerHealthPoint = GetVitality();
        }

        //current player vitality
        public float GetVitality()
        {
            return baseVitality + vitalityIncrement * vitality;
        }

        //current player vitality rounded
        public float DisplayVitality()
        {
            return _playerHealthPoint;
        }

        //current player defense
        public float GetDefense()
        {
            return defense == 1 ? baseDefense : Mathf.Log(defense) * defenseIncrement;
        }

        //current player defense rounded
        public float DisplayDefense()
        {
            return Mathf.Round(GetDefense());
        }

        //current player dexterity
        public float GetDexterity()
        {
            return Mathf.Log(dexterity) * dexterityIncrement + baseDexterity;
        }

        //current player dexterity rounded
        public float DisplayDexterity()
        {
            return Mathf.Round(GetDexterity());
        }
        
        //current player velocity
        public float GetVelocity()
        {
            return velocity * velocityIncrement;
        }

        //current player velocity rounded
        public float DisplayVelocity()
        {
            return Mathf.Round(GetVelocity());
        }

        //current player bonus damage
        public float GetDamageBonus()
        {
            return damageBonus * damageBonusIncrement;
        }
        
        //level up statistic
        public void LevelUp(Statistic stat)
        {
            switch (stat)
            {
                case Statistic.Vitality:
                    vitality++;
                    break;
                case Statistic.Defense:
                    defense++;
                    break;
                case Statistic.Dexterity:
                    dexterity++;
                    break;
                case Statistic.Velocity:
                    velocity++;
                    break;
                case Statistic.DamageBonus:
                    damageBonus++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(stat), stat, null);
            }
        }
        
        //player take damages
        public void PlayerDamaged(float damages)
        {
            _playerHealthPoint -= damages;
            Debug.Log("player took damage : " + _playerHealthPoint);
        }

        //player receive heals
        public void PlayerHealed(float heals)
        {
            _playerHealthPoint += heals;
        }
    }
    
    
}
