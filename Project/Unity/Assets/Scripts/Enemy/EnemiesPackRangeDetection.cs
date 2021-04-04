using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy
{
    public class EnemiesPackRangeDetection : MonoBehaviour
    {
        [SerializeField] private List<EnemyBehaviour> enemyList = new List<EnemyBehaviour>();

        private void OnTriggerEnter(Collider col)
        {
            if (!col.gameObject.CompareTag("Player")) return;
            foreach (var enemy in enemyList)
            {
                enemy.PlayerEnteredRange();
            }
        }
    }
}
