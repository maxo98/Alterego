using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private int roomWhereToSpawn;
    private float xValue;
    private float yValue;
    private float zValue;
    // Start is called before the first frame update
    private void Start()
    {
        if (!RoomTemplates.instance.key)
        {
            RoomTemplates.instance.key = this;
        }
    }
    public void Init()
    {
        xValue = Random.Range(-55f, 55f);
        Debug.Log("xvalue : " + xValue);
        yValue = -8f;
        zValue = Random.Range(-55f, 55f);
        Debug.Log("zvalue : " + zValue);
        Vector3 randomPos = new Vector3(xValue, yValue, zValue);
        roomWhereToSpawn = Random.Range(0, RoomTemplates.instance.rooms.Count - 2);
        transform.position = RoomTemplates.instance.rooms[roomWhereToSpawn].transform.position + randomPos;
        Debug.Log("La position de la clé est fixée");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BossRoomDoor.hasKey = true;
            Destroy(this.gameObject);
            //gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Rooms")
        {
            Init();
        }
    }
}
