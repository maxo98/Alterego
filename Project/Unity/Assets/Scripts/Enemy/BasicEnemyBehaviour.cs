using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class BasicEnemyBehaviour : EnemyBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private NavMeshAgent agent;

        private void Awake()
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            if (PlayerInRange)
            {
                Chasing();
            }
        }

        private void Chasing()
        {
            agent.SetDestination(playerTransform.position);
        }
    }
}
