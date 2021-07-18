using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDefeated : MonoBehaviour
{
    [SerializeField] private GameObject victoryScreen;

    public void VictoryScreen()
    {
        RoomTemplates.instance.VictoryScreen.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.GameisPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            VictoryScreen();
        }
    }
}
