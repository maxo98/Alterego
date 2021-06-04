using UnityEngine;

namespace ThirdPersonScripts
{
    public class ThirdPersonAnimationManager : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private ThirdPersonCombatController combatController;
        
        private static readonly int InputX = Animator.StringToHash("InputX");
        private static readonly int InputY = Animator.StringToHash("InputY");
        private static readonly int InputMagnitude = Animator.StringToHash("InputMagnitude");

        public void CharacterAnimationMovement(Vector2 inputs) 
        {
            animator.SetFloat(InputX, inputs.x);
            animator.SetFloat(InputY, inputs.y);
            animator.SetFloat(InputMagnitude, new Vector3(inputs.x, 0, inputs.y).magnitude);
        }
        

    }
}