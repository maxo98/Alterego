using UnityEngine;
using UnityEngine.Events;

namespace ThirdPersonScripts
{
    public class TriggerGroundDetectedEventDispatcher : MonoBehaviour
    {
        public UnityEvent triggerGroundDetected;

        private void OnTriggerEnter(Collider col)
        {
            triggerGroundDetected.Invoke();
        }
    }
}
