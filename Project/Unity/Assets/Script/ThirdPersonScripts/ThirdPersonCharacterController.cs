using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Script.ThirdPersonScripts
{
    public class ThirdPersonCharacterController : MonoBehaviour
    {

        [SerializeField] private Transform playerTransform;
        [SerializeField] private Rigidbody playerRigidbody;
        [SerializeField] private Transform cameraTransform;

        [SerializeField] private ThirdPersonCombatController combatController;
        [SerializeField] private ThirdPersonAnimationManager animationManager;
        
        [SerializeField] private float characterSpeed;
        [SerializeField] private float characterJumpSpeed;
        [SerializeField] private float characterDashForce;
        [SerializeField] private float fallMultiplier;

        [SerializeField] private CharacterSkill action1;

        private bool _jumping;
        private bool _dashing;
        private Vector3 _jumpIntent;
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
            
            _directionIntent = values.y * forward + values.x * right;
        }

        public void OnCharacterDash()
        {
            _dashing = true;
        }

        public void OnCharacterJump()
        {
            _jumping = true;
        }

        public void OnCharacterAction1()
        {
            Debug.Log("action1 used");
            action1.Use();
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            /*if (combatController.IsAttacking)
            {
                return;
            }*/

            if (_jumping)
            {
                _jumpIntent = Vector3.up;
                _jumping = false;
            }
            else
            {
                _jumpIntent = Vector3.zero;
            }

            playerRigidbody.AddForce(_directionIntent.x * characterSpeed, _jumpIntent.y * characterJumpSpeed, _directionIntent.z * characterSpeed, ForceMode.VelocityChange);

            if (_dashing)
            {
                _dashing = false;
                playerRigidbody.AddForce(_directionIntent.x * characterDashForce, playerRigidbody.velocity.y,
                    _directionIntent.z * characterDashForce, ForceMode.VelocityChange); 
            }
            
            if (playerRigidbody.velocity.y < 0)
            {
                playerRigidbody.velocity += Vector3.up * (Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime);
            }

            if (_directionIntent != Vector3.zero)
            {
                playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation,
                    Quaternion.LookRotation(_directionIntent), 0.1f);
            }

        }

    }
}
