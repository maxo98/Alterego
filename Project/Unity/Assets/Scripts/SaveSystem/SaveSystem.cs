using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public SaveObject[] so;
    int count = 0;
    public Transform level;
    public static bool destroyerFinish = false;
    private void Awake()
    {
        if (ObjectLoaderHelper.loadScene)
        {
            Debug.Log("je load");
            Time.timeScale = 0f;
            so = SaveManager.Load(level, ObjectLoaderHelper.instance.fileToLoad);
            DestroyOld(level);
            GetListIntoMap(so);
            Time.timeScale = 1f;
        }
    }
    public void SaveData()
    {
        GetMapIntoList();
        SaveManager.Save(SaveManager.saveFilename);
    }

    public void LoadData()
    {
        so = SaveManager.Load(level, Application.persistentDataPath + SaveManager.directory + SaveManager.saveFilename);
        DestroyOld(level);
        GetListIntoMap(so);
    }

    public void GetMapIntoList()
    {
        count = 0;
        so = new SaveObject[level.childCount];
        foreach (Transform child in level)
        {
            SaveObject _so = new SaveObject();
            _so.room = child.name;
            _so.Position = new float[3];
            _so.Rotation = new float[4];
            _so.Scale = new float[3];
            _so.Position[0] = child.localPosition.x;
            _so.Position[1] = child.localPosition.y;
            _so.Position[2] = child.localPosition.z;

            _so.Rotation[0] = child.localRotation.x;
            _so.Rotation[1] = child.localRotation.y;
            _so.Rotation[2] = child.localRotation.z;
            _so.Rotation[3] = child.localRotation.w;

            _so.Scale[0] = child.localScale.x;
            _so.Scale[1] = child.localScale.y;
            _so.Scale[2] = child.localScale.z;

            so[count] = _so;
            count++;
        }

        foreach (SaveObject item in so)
        {
            SaveManager.WriteIntoMyFile(item);
        }
    }

    public void GetListIntoMap(SaveObject[] _so)
    {
        GameObject[] _listGo = new GameObject[_so.Length];
        Debug.Log("La taille du SO dans save system : " + _listGo.Length);
        for (int i = 0; i < _so.Length; i++)
        {
            if (_so[i] != null)
            {
                Vector3 _pos = new Vector3(_so[i].Position[0], _so[i].Position[1], _so[i].Position[2]);
                Quaternion _rot = new Quaternion(_so[i].Rotation[0], _so[i].Rotation[1], _so[i].Rotation[2], _so[i].Rotation[3]);
                Vector3 _sca = new Vector3(_so[i].Scale[0], _so[i].Scale[1], _so[i].Scale[2]);
                Debug.Log(ObjectLoaderHelper.myDico[_so[i].room]);
                GameObject _go = Instantiate(ObjectLoaderHelper.myDico[_so[i].room], _pos, _rot, level);
                _go.name = ObjectLoaderHelper.myDico[_so[i].room].name;
                if (RoomTemplates.instance && i == _so.Length-2)
                {
                    _go.tag = "BossRoom";
                    RoomTemplates.instance.bossRoom = _go;
                }
                else if(RoomTemplates.instance && _go.name == "Key")
                {
                    RoomTemplates.instance.key = _go.GetComponent<Key>();
                }
                _go.transform.localScale = _sca;
                _listGo[i] = _go;
            }
        }
        KillChildren();

    }

    public void KillChildren()
    {
        foreach (Transform child in level)
        {
            foreach (Transform child2 in child)
            {
                if (child2.GetComponent<RoomSpawner>())
                {
                    Destroy(child2.gameObject);
                }
            }
        }
    }
    public void DestroyOld(Transform _level)
    {
        foreach (Transform child in _level)
        {
            Destroy(child.gameObject);
        }
        //Destroy(_so.myMap);
        destroyerFinish = true;
    }
}
