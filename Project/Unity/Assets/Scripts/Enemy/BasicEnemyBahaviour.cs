using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class BasicEnemyBahaviour : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;

        public bool playerInRange;
        public float range = 20f;

        public NavMeshAgent agent;

        private void Awake()
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            agent = GetComponent<NavMeshAgent>();
        }


        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range);
        }

        private void Update()
        {
            if (playerInRange)
            {
                Chasing();
            }
        }

        public void PlayerEnteredRange()
        {
            playerInRange = true;
        }

        public void Chasing()
        {
            agent.SetDestination(playerTransform.position);
        }
    }
}
