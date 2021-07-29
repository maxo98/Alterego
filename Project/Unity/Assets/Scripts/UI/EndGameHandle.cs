using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameHandle : MonoBehaviour
{
    [SerializeField] private static GameObject victoryScreen;
    [SerializeField] private static GameObject loseScreen;
    private void Awake()
    {
        victoryScreen = GameObject.FindGameObjectWithTag("Victory");
        loseScreen = GameObject.FindGameObjectWithTag("Lose");
    }
    public static void VictoryScreen()
    {
        victoryScreen.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.GameisPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public static void LoseScreen()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.GameisPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


}
