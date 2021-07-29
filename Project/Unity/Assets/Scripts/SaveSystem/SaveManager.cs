using UnityEngine;
using System.IO;

public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string saveFilename = "MyData.txt";
    public static string editorFilename = "MyDataFromEditor.txt";
    public static string json;

    public static void Save(string _file)
    {
        string _dir = Application.persistentDataPath + directory;
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

    public static SaveObject[] Load(Transform _level, string _file)
    {
        //SaveObject[] _so = new SaveObject();

        if (File.Exists(_file))
        {
            string _json = File.ReadAllText(_file);
            string[] splitJson = _json.Split(char.Parse("$"));
            SaveObject[] _so = new SaveObject[splitJson.Length-1];
            Debug.Log("La taille du Json est : " + splitJson.Length);
            for (int i = 0; i < splitJson.Length -1; i++)
            {
                _so[i] = JsonUtility.FromJson<SaveObject>(splitJson[i]);
            }
            //SaveSystem.DestroyOld(_oldSo);
            return _so;
        }
        else
        {
            Debug.Log("Le fichier de sauvegarde n'existe pas !");
            return null;
        }
        
    }
}
