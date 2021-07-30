using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameHandle : MonoBehaviour
{
    [SerializeField] private static RoomTemplates roomTemplates;

    public void VictoryScreen()
    {
        RoomTemplates.instance.VictoryScreen.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.GameisPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoseScreen()
    {
        RoomTemplates.instance.LoseScreen.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.GameisPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


}
