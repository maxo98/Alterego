using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ThirdPersonScripts
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private static GameObject pause;
        [SerializeField] private Slider sliderHealth;
        [SerializeField] private CharacterStatistic characterStatistic;

        private void Awake()
        {
            //pause = GameObject.FindGameObjectWithTag("UI_Pause");
        }

        private void Update()
        {
            sliderHealth.value = characterStatistic.DisplayVitality() / characterStatistic.GetVitality();
            if (characterStatistic.DisplayVitality() <= 0 && !EndGameHandle.done)
            {
                //pause.GetComponent<EndGameHandle>().LoseScreen();
                EndGameHandle.LoseScreen();
            }
        }
    }
}