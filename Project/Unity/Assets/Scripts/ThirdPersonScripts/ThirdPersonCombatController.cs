using System.Collections;
using UnityEngine;

namespace Script.ThirdPersonScripts
{
    public class ThirdPersonCombatController : MonoBehaviour
    {
        [SerializeField] private float comboResetDelay;
        [SerializeField] private int maxComboAttack;
        [SerializeField] private GameObject weapon;//Erwan's change
        private BoxCollider weaponHitBox;//Erwan's change


        [SerializeField] private ThirdPersonAnimationManager animationManager;

        public int PlayerClicks { get; set; }
        private bool IsAttacking { get; set; }
        private float _lastTimeClicked;

        private void Start()
        {
            weaponHitBox = weapon.GetComponent<BoxCollider>();//Erwan's change
        }

        public void OnCharacterLightAttack()
        {
            _lastTimeClicked = Time.time;
            PlayerClicks++;
            PlayerClicks = Mathf.Clamp(PlayerClicks, 0, maxComboAttack);
            IsAttacking = true;
            StartCoroutine(weaponAttack());
            animationManager.CharacterAnimationAttack("LightAttack",PlayerClicks);
        }

        IEnumerator weaponAttack() //Erwan's change
        {
            weaponHitBox.enabled = true;
            yield return new WaitForSeconds(1);
            weaponHitBox.enabled = false;
        }

        // Update is called once per frame
        private void Update()
        {
            if (!(Time.time - _lastTimeClicked > comboResetDelay))
            {
                return;
            }
            PlayerClicks = 0;
            IsAttacking = false;

        }
        
        
    }
}
