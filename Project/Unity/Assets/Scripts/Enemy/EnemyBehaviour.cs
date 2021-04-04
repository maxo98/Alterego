using UnityEngine;

namespace Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        protected bool PlayerInRange { get; private set; }
        
        public void PlayerEnteredRange()
        {
            PlayerInRange = true;
        }
    }
}
