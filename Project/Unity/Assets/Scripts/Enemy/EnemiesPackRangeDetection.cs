using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemiesPackRangeDetection : MonoBehaviour
    {
        private readonly List<GameObject> _enemyList = new List<GameObject>();

        private void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.CompareTag("enemy"))
            {
                _enemyList.Add(col.gameObject);
            }
            else if(col.gameObject.CompareTag("Player"))
            {
                foreach (var enemy in _enemyList)
                {
                    enemy.GetComponent<BasicEnemyBahaviour>().PlayerEnteredRange();
                }
            }
        }
    }
}
