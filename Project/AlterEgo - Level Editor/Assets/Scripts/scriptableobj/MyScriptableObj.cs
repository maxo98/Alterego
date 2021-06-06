using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SO", menuName = "Alterego/ObjectToSpawn", order = 1)]
public class MyScriptableObj : ScriptableObject
{
    public enum TypeObject { Props, Ennemis, Rooms, Loot };

    public string prefabName;
    public Sprite image;

    public TypeObject myType = TypeObject.Props;
    public GameObject myPrefab;
}