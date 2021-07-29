using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public int NombreMaxRoom;
    public static int NombreActuelRoom = 0;
    public bool stopGenerate = false;
    public static int ObjID = 0;
    public Dictionary<int, GameObject> EnnemyDico;

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
            Destroy(this.gameObject);
            Debug.Log("Il existe deja une instance de RoomTemplate");
        }
        DontDestroyOnLoad(this.gameObject);
        EnnemyDico = new Dictionary<int, GameObject>();
    }
    #endregion
    private void Update()
    {
        if (NombreActuelRoom >= NombreMaxRoom)
        {
            stopGenerate = true;
        }
    }
    public static int GetId()
    {
        int _temp = ObjID;
        ObjID++;
        return _temp;
    }

    public void SpawnEnnemis()
    {
        foreach (var item in EnnemyDico.Values)
        {
            item.SetActive(true);
        }
    }
}
