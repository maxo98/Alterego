using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public enum TypeEntree { Top, Bottom, Left, Right }
    public TypeEntree roomNeeded;
    // 1 --> need Bottom door
    // 2 --> need Top door
    // 3 --> need Left door
    // 4 --> need Right door
    private RoomManager rm;
    public RoomTemplates templates;
    public int rand;
    public bool spawned = false;

    Vector3 offset = new Vector3(0, 0, 0);
    private void Start()
    {
        rm = FindObjectOfType<RoomManager>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {
        if (spawned == false)
        {
            spawned = true;
            if (!rm.stopGenerate)
            {
                switch (roomNeeded)
                {
                    case TypeEntree.Top: //Spawn une room avec un porte TOP
                        offset.z += 1;
                        rand = Random.Range(0, templates.topRooms.Length);
                        Instantiate(templates.topRooms[rand], transform.position + offset, Quaternion.identity);
                        break;
                    case TypeEntree.Bottom: //Spawn une room avec un porte BOTTOM
                        offset.z -= 1;
                        rand = Random.Range(0, templates.bottomRooms.Length);
                        Instantiate(templates.bottomRooms[rand], transform.position + offset, Quaternion.identity);
                        break;
                    case TypeEntree.Left: //Spawn une room avec un porte LEFT
                        offset.x -= 1;
                        rand = Random.Range(0, templates.leftRooms.Length);
                        Instantiate(templates.leftRooms[rand], transform.position + offset, Quaternion.identity);
                        break;
                    case TypeEntree.Right: //Spawn une room avec un porte RIGHT
                        offset.x += 1;
                        rand = Random.Range(0, templates.rightRooms.Length);
                        Instantiate(templates.rightRooms[rand], transform.position + offset, Quaternion.identity);
                        break;
                    default:
                        break;
                }
                rm.NombreActuelRoom++;
            }
            else
            {
                switch (roomNeeded)
                {
                    case TypeEntree.Top: //Spawn une room avec un porte TOP
                        offset.z += 1;
                        rand = Random.Range(0, templates.topRooms.Length);
                        Instantiate(templates.closedHaut, transform.position + offset, Quaternion.identity);
                        break;
                    case TypeEntree.Bottom: //Spawn une room avec un porte BOTTOM
                        offset.z -= 1;
                        rand = Random.Range(0, templates.bottomRooms.Length);
                        Instantiate(templates.closedBas, transform.position + offset, Quaternion.identity);
                        break;
                    case TypeEntree.Left: //Spawn une room avec un porte LEFT
                        offset.x -= 1;
                        rand = Random.Range(0, templates.leftRooms.Length);
                        Instantiate(templates.closedGauche, transform.position + offset, Quaternion.identity);
                        break;
                    case TypeEntree.Right: //Spawn une room avec un porte RIGHT
                        offset.x += 1;
                        rand = Random.Range(0, templates.rightRooms.Length);
                        Instantiate(templates.closedDroite, transform.position + offset, Quaternion.identity);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnvSpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false ) // Spawn un mur qui empêche d'aller dans le vide
            {
                Instantiate(templates.closedRoom , transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
            
        }
    }

}
