using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomDoor : MonoBehaviour
{
    public ParticleSystem PS;
    public GameObject blocker;
    static public bool hasKey = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasKey)
        {
            PS.Stop();
            blocker.SetActive(false);
        }
    }
}
