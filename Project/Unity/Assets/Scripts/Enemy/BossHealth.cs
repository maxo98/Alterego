using ThirdPersonScripts;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class BossHealth : MonoBehaviour
    {
        [SerializeField] private CharacterStatistic characterStatistic;
       // private static GameObject _pause;
        [SerializeField] private Slider sliderHealth;

        private void Awake()
        {
            //_pause = GameObject.FindGameObjectWithTag("UI_Pause");
        }
        
        private void Update()
        {
            sliderHealth.value = characterStatistic.DisplayVitality() / characterStatistic.GetVitality();
            if (characterStatistic.DisplayVitality() <= 0 && !EndGameHandle.done)
            {
                //_pause.GetComponent<EndGameHandle>().VictoryScreen();
                EndGameHandle.VictoryScreen();
            }
        }
    }
}