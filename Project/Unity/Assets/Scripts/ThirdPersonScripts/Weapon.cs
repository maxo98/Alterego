using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("SLASH");
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (rb != null && rb.gameObject.tag == "enemy")
        {
            Vector3 direction = player.transform.position - other.transform.position;
            direction.y = 0;

            rb.AddForce(direction.normalized * -500, ForceMode.Force);
            AddDamage(rb.gameObject);
        }
    }

    public void AddDamage(GameObject _go)
    {
        _go.GetComponent<EnemyHealth>().DoDamage(40);
    }



}
