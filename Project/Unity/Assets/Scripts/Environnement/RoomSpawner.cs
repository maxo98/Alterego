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
    public GameObject closedRoom;
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
                        GameObject _go = Instantiate(templates.topRooms[rand], transform.position + offset, Quaternion.identity, RoomTemplates.instance.level);
                        _go.name = templates.topRooms[rand].name;
                        break;
                    case TypeEntree.Bottom: //Spawn une room avec un porte BOTTOM
                        offset.z -= 1;
                        rand = Random.Range(0, templates.bottomRooms.Length);
                        GameObject _go1 = Instantiate(templates.bottomRooms[rand], transform.position + offset, Quaternion.identity, RoomTemplates.instance.level);
                        _go1.name = templates.bottomRooms[rand].name;
                        break;
                    case TypeEntree.Left: //Spawn une room avec un porte LEFT
                        offset.x -= 1;
                        rand = Random.Range(0, templates.leftRooms.Length);
                        GameObject _go2 = Instantiate(templates.leftRooms[rand], transform.position + offset, Quaternion.identity, RoomTemplates.instance.level);
                        _go2.name = templates.leftRooms[rand].name;
                        break;
                    case TypeEntree.Right: //Spawn une room avec un porte RIGHT
                        offset.x += 1;
                        rand = Random.Range(0, templates.rightRooms.Length);
                        GameObject _go3 = Instantiate(templates.rightRooms[rand], transform.position + offset, Quaternion.identity, RoomTemplates.instance.level);
                        _go3.name = templates.rightRooms[rand].name;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (roomNeeded)
                {
                    case TypeEntree.Top: //Spawn une room avec un porte TOP
                        offset.z += 1;
                        rand = Random.Range(0, templates.topRooms.Length);
                        GameObject _go = Instantiate(templates.closedHaut, transform.position + offset, Quaternion.identity, RoomTemplates.instance.level);
                        _go.name = templates.closedHaut.name;
                        break;
                    case TypeEntree.Bottom: //Spawn une room avec un porte BOTTOM
                        offset.z -= 1;
                        rand = Random.Range(0, templates.bottomRooms.Length);
                        GameObject _go1 = Instantiate(templates.closedBas, transform.position + offset, Quaternion.identity, RoomTemplates.instance.level);
                        _go1.name = templates.closedBas.name;
                        break;
                    case TypeEntree.Left: //Spawn une room avec un porte LEFT
                        offset.x -= 1;
                        rand = Random.Range(0, templates.leftRooms.Length);
                        GameObject _go2 = Instantiate(templates.closedGauche, transform.position + offset, Quaternion.identity, RoomTemplates.instance.level);
                        _go2.name = templates.closedGauche.name;
                        break;
                    case TypeEntree.Right: //Spawn une room avec un porte RIGHT
                        offset.x += 1;
                        rand = Random.Range(0, templates.rightRooms.Length);
                        GameObject _go3 = Instantiate(templates.closedDroite, transform.position + offset, Quaternion.identity, RoomTemplates.instance.level);
                        _go3.name = templates.closedDroite.name;
                        break;
                    default:
                        break;
                }
            }
 
            

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnvSpawnPoint") && !ObjectLoaderHelper.loadScene)
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false ) // Spawn un mur qui empêche d'aller dans le vide
            {
                GameObject _go = Instantiate(closedRoom, transform.position, Quaternion.identity, RoomTemplates.instance.level);
                Debug.Log("je fais spawn une salle fermée");
                _go.name = closedRoom.name;
                Destroy(gameObject);
            }
            spawned = true;
            
        }
    }

}
