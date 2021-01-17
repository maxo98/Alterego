using UnityEngine;
using UnityEngine.InputSystem;

namespace Script.ThirdPersonScripts
{
    public class ThirdPersonCharacterController : MonoBehaviour
    {

        [SerializeField] private Transform playerTransform;
        [SerializeField] private Transform cameraTransform;

        [SerializeField] private ThirdPersonCombatController combatController;
        [SerializeField] private ThirdPersonAnimationManager animationManager;
        
        [SerializeField] private float characterSpeed;
      
        private Vector3 _directionIntent;
        private Vector3 _rotationIntent;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnCharacterMovement(InputValue inputs)
        {
            var values = inputs.Get<Vector2>();
            
            var forward = cameraTransform.forward;
            var right = cameraTransform.right;
            
            forward.y = 0f;
            right.y = 0f;
            
            forward.Normalize();
            right.Normalize();
            
            animationManager.CharacterAnimationMovement(values);

            _directionIntent =  values.y * forward + values.x * right;

        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            if (combatController.IsAttacking)
            {
                return;
            }
            playerTransform.Translate(_directionIntent * (characterSpeed * Time.deltaTime), Space.World);

            if (_directionIntent != Vector3.zero)
            {
                playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation,
                    Quaternion.LookRotation(_directionIntent), 0.1f);
            }

        }

    }
}
