using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomDoor : MonoBehaviour
{
    public ParticleSystem PS;
    public GameObject blocker;
    public MeshRenderer Light1;
    public MeshRenderer Light2;
    static public bool hasKey = false;

    private void Update()
    {
        Light1.enabled = hasKey;
        Light2.enabled = hasKey;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasKey)
        {
            PS.Stop();
            blocker.SetActive(false);
            hasKey = false;
        }
    }
}
