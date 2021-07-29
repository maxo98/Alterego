using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorManager : MonoBehaviour
{
    [SerializeField] private MousePosition mouse;
    public Material defaultMat;
    public Material GhostMat;

    public Dictionary<int, itemController> itemButtons = new Dictionary<int, itemController>();
    public int itemsCount = 0;
    public GameObject[] itemPrefabs;
    public Transform Environnement;
    Vector3 offset = new Vector3(0, 11, 0);
    Vector3 offsetBalcon = new Vector3(-2, 0, 0);

    [SerializeField] private Camera mainCamera;
    //   public GameObject[] itemImage;



    public int CurrentButtonPressed = 0;

    private void Update()
    {
        if (itemButtons.Count != 0)
        {
            if (Input.GetMouseButtonDown(0) && itemButtons[CurrentButtonPressed].Clicked)
            {
                itemController _item = itemButtons[CurrentButtonPressed];
                _item.Clicked = false;
                _item.currentGO.GetComponent<Renderer>().material = defaultMat;
                Destroy(_item.currentGO.GetComponent<ItFollows>());
                if (_item.mySO.myType == MyScriptableObj.TypeObject.Rooms)
                {
                    _item.currentGO.transform.position += offset;
                }
                if (_item.currentGO.name == "Balcon")
                {
                    if (_item.currentGO.transform.position.y > 1.3f)
                    {
                        _item.currentGO.transform.position += offsetBalcon;
                        Debug.Log("fait");
                    }
                }
                _item.currentGO.layer = 8;
                
            }
        }


    }
}
