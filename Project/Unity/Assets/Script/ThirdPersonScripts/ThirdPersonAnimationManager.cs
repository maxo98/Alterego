using UnityEngine;

namespace Script.ThirdPersonScripts
{
    public class ThirdPersonAnimationManager : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private ThirdPersonCombatController combatController;
        
        private static readonly int InputX = Animator.StringToHash("InputX");
        private static readonly int InputY = Animator.StringToHash("InputY");
        private static readonly int InputMagnitude = Animator.StringToHash("InputMagnitude");
        private static readonly int LightAttack2 = Animator.StringToHash("LightAttack2");
        private static readonly int LightAttack1 = Animator.StringToHash("LightAttack1");

        public void CharacterAnimationMovement(Vector2 inputs) 
        {
            animator.SetFloat(InputX, inputs.x);
            animator.SetFloat(InputY, inputs.y);
            animator.SetFloat(InputMagnitude, new Vector3(inputs.x, 0, inputs.y).magnitude);
        }

        public void CharacterAnimationAttack(string attackName, int attackCount)
        {
            if (attackCount == 1)
            {
                animator.SetBool($"{attackName}{attackCount.ToString()}", true);
            }
        }

        public void LightAttackEnd1()
        {
            
            if (combatController.PlayerClicks >= 2)
            {
                animator.SetBool(LightAttack2, true);
            }
            else
            {
                animator.SetBool(LightAttack1, false);
                combatController.PlayerClicks = 0;
            }
        }
        
        public void LightAttackEnd2()
        {
            
            animator.SetBool(LightAttack1, false);
            animator.SetBool(LightAttack2, false);
            combatController.PlayerClicks = 0;
        }

    }
}