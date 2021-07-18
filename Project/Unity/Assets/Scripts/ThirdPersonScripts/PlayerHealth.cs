using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ThirdPersonScripts
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private GameObject healthUI;
        [SerializeField] private Slider sliderHealth;
        [SerializeField] private CharacterStatistic characterStatistic;

        private void Update()
        {
            sliderHealth.value = characterStatistic.DisplayVitality() / characterStatistic.GetVitality();
        }
    }
}