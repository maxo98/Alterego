using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyBahaviour : MonoBehaviour
{
    public Transform player;
    public float speed = 4f;
    private Rigidbody rb;

    public bool isCloseEnought;
    public float range = 20f;

    public NavMeshAgent agent;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody>();
        agent = this.GetComponent<NavMeshAgent>();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Update()
    {
        CheckDistanceToPlayer();
        if (isCloseEnought)
        {
            Chasing();
        }
    }

    public void CheckDistanceToPlayer()
    {
        Debug.Log("Analysing");
        float _distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (_distanceToPlayer < range)
        {
            isCloseEnought = true;
        }
    }

    public void Chasing()
    {
        Debug.Log("Chasing");
        agent.SetDestination(player.position);
    }
}
