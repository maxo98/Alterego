using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void LoadNextLevel()
    {
       StartCoroutine(LoadLevel(1)); // Ou SceneManager.GetActiveScene().buildIndex + 1; pour la scene qui suit dans le build manager
    }

    IEnumerator LoadLevel(int _levelIndex)
    {
        //Play Animation
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(_levelIndex);

    }
}
