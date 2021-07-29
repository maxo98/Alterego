using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ObjectLoaderHelper : MonoBehaviour
{
    public GameObject[] myList;
    public static Dictionary<string, GameObject> myDico;
    public GameObject Player;
    public static bool loadScene;
    string fileToLoad;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        myDico = new Dictionary<string, GameObject>();
        myList = Resources.LoadAll<GameObject>("Map rooms");
        foreach (GameObject item in myList)
        {
            myDico.Add(item.name, item);
        }
    }

    public void LoadScene()
    {
        loadScene = true;
    }

    public void FromSave()
    {
        fileToLoad = Application.persistentDataPath + SaveManager.directory + SaveManager.saveFilename;
    }
    public void FromEditor()
    {

    }
}
