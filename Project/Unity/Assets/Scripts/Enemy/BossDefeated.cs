using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDefeated : MonoBehaviour
{
    [SerializeField] private GameObject victoryScreen;

    public void VictoryScreen()
    {
        victoryScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
