using System.Collections;
using System.Collections.Generic;
using UnityEditor.AI;
using UnityEngine;

public class RoomCount : MonoBehaviour
{

    RoomTemplates templates;
    void Start()
    {
        RoomManager.NombreActuelRoom++;

        templates = FindObjectOfType<RoomTemplates>();
        templates.rooms.Add(this.gameObject);

        NavMeshBuilder.BuildNavMeshAsync();
    }

}
