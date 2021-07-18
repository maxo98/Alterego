using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void LoadNewGame()
    {
       StartCoroutine(LoadLevel(1)); // Ou SceneManager.GetActiveScene().buildIndex + 1; pour la scene qui suit dans le build manager
    }
    public void LoadLevelFromASave()
    {
        StartCoroutine(LoadLevel(2)); // Ou SceneManager.GetActiveScene().buildIndex + 1; pour la scene qui suit dans le build manager
    }
    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void LoadScene()
    {
        ObjectLoaderHelper.loadScene = true;
    }
    public void NewGame()
    {
        ObjectLoaderHelper.instance.fileToLoad = null;
    }
    public void FromSave()
    {
        ObjectLoaderHelper.instance.fileToLoad = Application.persistentDataPath + SaveManager.directory + SaveManager.saveFilename;
    }
    public void FromEditor()
    {
        ObjectLoaderHelper.instance.fileToLoad = Application.persistentDataPath + SaveManager.directory + SaveManager.editorFilename;
    }



    IEnumerator LoadLevel(int _levelIndex)
    {
        //Play Animation
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(_levelIndex);
    }
}
