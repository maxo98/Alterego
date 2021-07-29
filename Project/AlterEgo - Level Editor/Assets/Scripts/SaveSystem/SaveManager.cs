using UnityEngine;
using System.IO;

public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string saveFilename = "MyData.txt";
    public static string editorFilename = "MyDataFromEditor.txt";
    public static string json;

    public static void Save(string _file, string _dir)
    {
        if (!Directory.Exists(_dir))
        {
            Directory.CreateDirectory(_dir);
        }
        Debug.Log(_dir);
        
        File.WriteAllText(_dir + _file, json);
        json = null;
    }

    public static void WriteIntoMyFile(SaveObject _so)
    {
        json += JsonUtility.ToJson(_so);
        json += "$\n";
    }

    public static SaveObject[] Load(Transform _level, string _file, string _dir)
    {
        string _fullPath = _dir + _file;
        //SaveObject[] _so = new SaveObject();

        if (File.Exists(_fullPath))
        {
            string _json = File.ReadAllText(_fullPath);
            string[] splitJson = _json.Split(char.Parse("$"));
            SaveObject[] _so = new SaveObject[splitJson.Length];
            Debug.Log("La taille du Json est : " + splitJson.Length);
            for (int i = 0; i < splitJson.Length -1; i++)
            {
                _so[i] = JsonUtility.FromJson<SaveObject>(splitJson[i]);
                Debug.Log(_so[i].room);
            }
            //_so = JsonUtility.FromJson<SaveObject>(_json);
            //SaveSystem.DestroyOld(_oldSo);
            Debug.Log("voici la liste dans Load : " + _so);
            return _so;
        }
        else
        {
            Debug.Log("Le fichier de sauvegarde n'existe pas !");
            return null;
        }
        
    }
}
