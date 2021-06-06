using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPopulate : MonoBehaviour
{
    public MyScriptableObj[] MyScriptable;
    public GameObject buttonprefab;
    private LevelEditorManager editor;

    void Start()
    {
        editor = GameObject.FindGameObjectWithTag("LevelEditorManager").GetComponent<LevelEditorManager>();

        foreach (MyScriptableObj mySO in MyScriptable)
        {
            GameObject _go = Instantiate(buttonprefab, this.transform);
            itemController _ic = _go.GetComponent<itemController>();
            _ic.mySO = mySO;
            _ic.GetComponent<Image>().sprite = mySO.image;
            _ic.ID = editor.itemsCount;
            editor.itemsCount++;
            editor.itemButtons.Add(_ic.ID, _ic);
            
        }
    }

}
