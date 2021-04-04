using System;
using UnityEngine;

namespace ThirdPersonScripts
{
    
    public enum Statistic {Vitality, Defense, Dexterity, Velocity, DamageBonus}
    
    public class CharacterStatistic : MonoBehaviour
    {
        
        private Statistic _statistics;
        
        public int Vitality { get; private set; }
        [SerializeField] private float vitalityIncrement;
        [SerializeField] private float baseVitality;
        public int Defense { get; private set; }
        [SerializeField] private float defenseIncrement;
        [SerializeField] private float baseDefense;
        public int Dexterity { get; private set; }
        [SerializeField] private float dexterityIncrement;
        [SerializeField] private float baseDexterity;
        public int Velocity { get; private set; }
        [SerializeField] private float velocityIncrement;
        public int DamageBonus { get; private set; }
        [SerializeField] private float damageBonusIncrement;

        public float PlayerHealthPoint { get; private set; }
        
        //current player vitality
        public float GetVitality()
        {
            return baseVitality + vitalityIncrement * Vitality;
        }

        //current player vitality rounded
        public float DisplayVitality()
        {
            return Mathf.Round(GetVitality());
        }

        //current player defense
        public float GetDefense()
        {
            return Defense == 1 ? baseDefense : Mathf.Log(Defense) * defenseIncrement;
        }

        //current player defense rounded
        public float DisplayDefense()
        {
            return Mathf.Round(GetDefense());
        }

        //current player dexterity
        public float GetDexterity()
        {
            return Mathf.Log(Dexterity) * dexterityIncrement + baseDexterity;
        }

        //current player dexterity rounded
        public float DisplayDexterity()
        {
            return Mathf.Round(GetDexterity());
        }
        
        //current player velocity
        public float GetVelocity()
        {
            return Velocity * velocityIncrement;
        }

        //current player velocity rounded
        public float DisplayVelocity()
        {
            return Mathf.Round(GetVelocity());
        }

        //current player bonus damage
        public float GetDamageBonus()
        {
            return DamageBonus * damageBonusIncrement;
        }
        
        //level up statistic
        public void LevelUp(Statistic stat)
        {
            switch (stat)
            {
                case Statistic.Vitality:
                    Vitality++;
                    break;
                case Statistic.Defense:
                    Defense++;
                    break;
                case Statistic.Dexterity:
                    Dexterity++;
                    break;
                case Statistic.Velocity:
                    Velocity++;
                    break;
                case Statistic.DamageBonus:
                    DamageBonus++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(stat), stat, null);
            }
        }
        
        //player take damages
        public void PlayerDamaged(float damages)
        {
            PlayerHealthPoint -= damages;
        }

        //player receive heals
        public void PlayerHealed(float heals)
        {
            PlayerHealthPoint += heals;
        }
    }
    
    
}
