using System.Collections;
using System.Collections.Generic;
using UnityEditor.AI;
using UnityEngine;

public class RoomCount : MonoBehaviour
{
    public GameObject[] MyEnnemy;
    RoomTemplates templates;
    void Start()
    {
        RoomManager.NombreActuelRoom++;

        templates = FindObjectOfType<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
        if (MyEnnemy != null)
        {
            RoomManager.instance.EnnemyDico.Add(gameObject, MyEnnemy);
        }
        NavMeshBuilder.BuildNavMeshAsync();
    }

}
