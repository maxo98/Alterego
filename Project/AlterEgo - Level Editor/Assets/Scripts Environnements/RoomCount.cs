using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCount : MonoBehaviour
{
    RoomManager rm;
    void Start()
    {
        rm = FindObjectOfType<RoomManager>();
        rm.NombreActuelRoom++;
    }

}
