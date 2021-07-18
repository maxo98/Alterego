using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public Transform level;

    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public GameObject closedHaut;
    public GameObject closedBas;
    public GameObject closedDroite;
    public GameObject closedGauche;

    public List<GameObject> rooms;
    public GameObject BossRoom;
    public GameObject BossDoor;

    private float waitTime = 2f;
    private bool spawnedBoss;
    public GameObject boss;
    private int tempCount;
    private bool endBoss;
    public Key key;

    private Vector3 doorOffsetZ;
    private Vector3 doorOffsetX;

    public GameObject VictoryScreen;

    #region Singleton

    public static RoomTemplates instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            Debug.Log("Il existe deja une instance de RoomTemplate");
        }
    }
    #endregion
    private void Start()
    {
        tempCount = 0;
    }
    private void Update()
    {
        if (!endBoss)
        {
            SpawnTheBoss();
        }


    }
    void SpawnTheBoss()
    {
        if (tempCount == rooms.Count) // on vérifie que la génération est bien terminé
        {
            if (waitTime <= 0 && !spawnedBoss) // on verifie que la fin du timer est pas inferieur on égal à 0
            {
                BossRoom = rooms[rooms.Count - 1];
                GameObject _tempBoss = Instantiate(boss, BossRoom.transform.position - (transform.up * 5), Quaternion.identity);
                BossRoom.name = "BossRoom";
                spawnedBoss = true;
                DestroyAllRoomsChildren(BossRoom.transform);
                key.Init();
                endBoss = true;
                level.GetComponent<NavMeshSurface>().BuildNavMesh();
            }
            else // On diminue le timer avec le temps
            {
                waitTime -= Time.deltaTime;
            }
        }
        else  // sinon on reset le timer avant le spawn du boss 
        {
            waitTime = 2f;
            tempCount = rooms.Count;
        }
    }

    void SpawnBossDoor(GameObject _bossRoom)
    {
        RaycastHit hit;
        if (Physics.Raycast(_bossRoom.transform.position, _bossRoom.transform.forward * 10, out hit))
        {
            doorOffsetZ = new Vector3(0, -10, 62);
            CheckTheDoorToSpawn(hit, _bossRoom.transform.position + doorOffsetZ, Quaternion.identity);
            Debug.Log("Le forward a touché : " + hit.transform.gameObject.name);
        }
        if (Physics.Raycast(_bossRoom.transform.position, _bossRoom.transform.forward * -70, out hit))
        {
            doorOffsetZ = new Vector3(0, -10, -55);
            CheckTheDoorToSpawn(hit, _bossRoom.transform.position + doorOffsetZ, Quaternion.identity);
            Debug.Log("Le backward a touché : " + hit.transform.gameObject.name);
        }
        if (Physics.Raycast(_bossRoom.transform.position, _bossRoom.transform.right * 70, out hit))
        {
            doorOffsetX = new Vector3(62, -10, 0);
            CheckTheDoorToSpawn(hit, _bossRoom.transform.position + doorOffsetX, Quaternion.Euler(0, 90, 0));
            Debug.Log("Le droit a touché : " + hit.transform.gameObject.name);
        }
        if (Physics.Raycast(_bossRoom.transform.position, _bossRoom.transform.right * -70, out hit))
        {
            doorOffsetX = new Vector3(-55, -10, 0);
            CheckTheDoorToSpawn(hit, _bossRoom.transform.position + doorOffsetX, Quaternion.Euler(0, 90, 0));
            Debug.Log("Le gauche a touché : " + hit.transform.gameObject.name);
        }
        else
        {
            Debug.Log("Quelque chose a foiré avec la salle du boss");
        }
    }
    void CheckTheDoorToSpawn(RaycastHit _hit, Vector3 _spawnPoint, Quaternion _orientation)
    {
        if (_hit.transform.gameObject.name != "BossRoom")
        {
            Instantiate(BossDoor, _spawnPoint, _orientation, level);
        }
    }
    void DestroyAllRoomsChildren(Transform _room)
    {

        for (int i = 0; i < _room.childCount; i++)
        {
            Destroy(_room.GetChild(i).gameObject);
        }
        SpawnBossDoor(BossRoom);
    }
}
