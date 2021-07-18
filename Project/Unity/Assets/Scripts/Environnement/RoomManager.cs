using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public int NombreMaxRoom;
    public static int NombreActuelRoom = 0;
    public bool stopGenerate = false;

    private void Update()
    {
        if (NombreActuelRoom >= NombreMaxRoom)
        {
            stopGenerate = true;
        }
    }
}
