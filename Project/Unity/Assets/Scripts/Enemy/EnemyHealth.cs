using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject healthUI;
    public Slider sliderHealth;

    [SerializeField] private GameObject victoryScreen;

    private void Start()
    {
        health = maxHealth;
        sliderHealth.value = CalculateHealth();
    }

    private void Update()
    {
        sliderHealth.value = CalculateHealth();

        if (health < maxHealth)
        {
            healthUI.SetActive(true);
        }

        if (health <= 0)
        {
            if (gameObject.name == "BossVisual")
            {
                PauseMenu.GameisPaused = true;
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                victoryScreen.SetActive(true);
            }
            Destroy(gameObject);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }

    public void DoDamage(float _dmg)
    {
        health -= _dmg;
        StartCoroutine(WaitAfterDealingDamage());
    }

    IEnumerator WaitAfterDealingDamage()
    {
        yield return new WaitForSeconds(1);
    }
}
