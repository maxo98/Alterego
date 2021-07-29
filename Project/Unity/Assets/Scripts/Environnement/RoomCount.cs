using UnityEngine;

public class RoomCount : MonoBehaviour
{
    RoomTemplates templates;
    public GameObject[] ennemis;
    private int id;
    void Start()
    {
        RoomManager.NombreActuelRoom++;
        foreach (var item in ennemis)
        {
            id = RoomManager.GetId();
            RoomManager.instance.EnnemyDico.Add(id, item);
        }

        templates = FindObjectOfType<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
    }

}
