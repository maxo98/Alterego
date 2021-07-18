using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        public GameObject Player { get; set; }
        
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] protected float sightRange;
        private bool PlayerInRange { get; set; }
        private bool PlayerInAttackRange { get; set; }

        private Vector3 _spawn;
        private bool _alreadyAttacked;

        private void Start()
        {
            _spawn = transform.position;
        }

        private void Update()
        {
            if (PlayerInRange)
            {
                PlayerInSight();
                Chasing();
                Attack();
            }
            else
            {
                BackToSpawn();
            }
        }
        
        public void PlayerEnteredRange()
        {
            PlayerInRange = true;
        }

        private void PlayerInSight()
        {
            if (Vector3.Distance(transform.position, Player.transform.position) > sightRange)
            {
                PlayerInRange = false;
            }
        }

        private void Chasing()
        {
            agent.SetDestination(Player.transform.position);
        }

        private void BackToSpawn()
        {
            agent.SetDestination(_spawn);
        }

        protected virtual void Attack(){}
    }
}
