using Script.ThirdPersonScripts;
using UnityEngine;

namespace ThirdPersonScripts
{
    public class ThirdPersonCombatController : MonoBehaviour
    {
        [SerializeField] private float comboResetDelay;
        [SerializeField] private int maxComboAttack;

        [SerializeField] private CharacterStatistic characterStatistic;
        [SerializeField] private CharacterAutoAttacks characterAutoAttacks;
        [SerializeField] private ThirdPersonAnimationManager animationManager;

        public int PlayerClicks { get; set; }
        private float _lastTimeClicked;

        public void OnCharacterLightAttack()
        {
            _lastTimeClicked = Time.time;
            PlayerClicks++;
            PlayerClicks = Mathf.Clamp(PlayerClicks, 0, maxComboAttack);
            characterAutoAttacks.Activate(PlayerClicks);
            animationManager.CharacterAnimationAttack("LightAttack",PlayerClicks);
        }

        // Update is called once per frame
        private void Update()
        {
            if (!(Time.time - _lastTimeClicked > comboResetDelay))
            {
                return;
            }
            PlayerClicks = 0;
        }
        
        
    }
}
