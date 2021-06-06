using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class itemController : MonoBehaviour
{
    [SerializeField] private MousePosition mouse;
    //[SerializeField] private TypeObject myTO;
    //enum TypeObject { Props, Ennemis, Rooms, Loot};
    public MyScriptableObj mySO;
    private LevelEditorManager editor;
    public int ID;
    public bool Clicked = false;
    public GameObject currentGO;
    Vector3 offset = new Vector3(0, 11, 0);


    private void Start()
    {
        editor = GameObject.FindGameObjectWithTag("LevelEditorManager").GetComponent<LevelEditorManager>();
        mouse = GameObject.FindGameObjectWithTag("Mouse").GetComponent<MousePosition>();
    }
    public void ButtonClicked()
    {
        switch (mySO.myType)
        {
            case MyScriptableObj.TypeObject.Props:
                GetProps();
                break;
            case MyScriptableObj.TypeObject.Ennemis:
                break;
            case MyScriptableObj.TypeObject.Rooms:
                GetRooms();
                break;
            case MyScriptableObj.TypeObject.Loot:
                break;
            default:
                break;
        }
    }

    private void GetProps()
    {
        Clicked = true;
        currentGO = Instantiate(mySO.myPrefab, mouse.position, Quaternion.identity, editor.Environnement);
        currentGO.GetComponent<Renderer>().material = editor.GhostMat;
        currentGO.AddComponent<ItFollows>();
        editor.CurrentButtonPressed = ID;
    }

    private void GetEnnemis()
    {
        Clicked = true;
        currentGO = Instantiate(mySO.myPrefab, mouse.position, Quaternion.identity);
        currentGO.GetComponent<Renderer>().material = editor.GhostMat;
        currentGO.AddComponent<ItFollows>();
        editor.CurrentButtonPressed = ID;
    }

    private void GetRooms()
    {
        Clicked = true;
        currentGO = Instantiate(mySO.myPrefab, mouse.position + offset, Quaternion.identity, editor.Environnement);
        currentGO.GetComponent<Renderer>().material = editor.GhostMat;
        currentGO.AddComponent<ItFollows>();
        editor.CurrentButtonPressed = ID;
    }

    private void GetLoot()
    {
        Clicked = true;
        currentGO = Instantiate(mySO.myPrefab, mouse.position, Quaternion.identity);
        currentGO.GetComponent<Renderer>().material = editor.GhostMat;
        currentGO.AddComponent<ItFollows>();
        editor.CurrentButtonPressed = ID;
    }
}
