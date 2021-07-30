using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameHandle : MonoBehaviour
{
    [SerializeField] private static RoomTemplates roomTemplates;
    public static bool done = false;
    public static void VictoryScreen()
    {
        done = true;
        RoomTemplates.instance.VictoryScreen.SetActive(true);
        //Time.timeScale = 0f;
        PauseMenu.GameisPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public static void LoseScreen()
    {
        done = true;
        RoomTemplates.instance.LoseScreen.SetActive(true);
        //Time.timeScale = 0f;
        PauseMenu.GameisPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


}
