using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public int NombreMaxRoom;
    public static int NombreActuelRoom = 0;
    public bool stopGenerate = false;
    public Dictionary<GameObject, GameObject[]> EnnemyDico;

    #region Singleton

    public static RoomManager instance;

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

        EnnemyDico.Clear();
        EnnemyDico = new Dictionary<GameObject, GameObject[]>();
    }
    #endregion
    private void Update()
    {
        if (NombreActuelRoom >= NombreMaxRoom)
        {
            stopGenerate = true;
        }
    }

    public void SpawnEnnemis()
    {
        foreach (var item in EnnemyDico)
        {
            foreach (var zone in item.Value)
            {
                zone.SetActive(true);
            }
        }
    }
}
