using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public Transform level;
    public GameObject test;

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
    public GameObject bossRoom;
    public GameObject bossDoor;

    public GameObject boss;


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
}
