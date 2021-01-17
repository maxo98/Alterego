using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Script
{
    public class ThirdPersonCameraController : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform targetTransform;
        
        [SerializeField] private float rotationSpeedX = 2f;
        [SerializeField] private float rotationSpeedY = 2f;
        [SerializeField] private float minAngle = -35;
        [SerializeField] private float maxAngle = 35;
        
        private float _lookAngle;
        private float _tiltAngle;

        protected void OnCameraRotation(InputValue inputs)
        {
            var values = inputs.Get<Vector2>();
            
            _lookAngle += values.x * rotationSpeedX;
            _tiltAngle -= values.y * rotationSpeedY;
            _tiltAngle = Mathf.Clamp(_tiltAngle, minAngle, maxAngle);

        }

        private void LateUpdate()
        {
            cameraTransform.LookAt(targetTransform);
            targetTransform.rotation = Quaternion.Euler(_tiltAngle, _lookAngle, 0);
        }
    }
}
