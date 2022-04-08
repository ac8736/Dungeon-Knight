using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void TakeDamage(int damage) {
        if (damage < 0) {
            if (currentHealth < maxHealth) {
                currentHealth -= damage;
                if (currentHealth > 100) {
                    currentHealth = 100;
                }
                healthBar.SetHealth(currentHealth);
            }
        } else {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }

    private void Update() {
        if (currentHealth <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.F) && GlobalVars.healthPotions > 0 && currentHealth < maxHealth) {
            TakeDamage(-10);
            GlobalVars.healthPotions -= 1;
        }
    }
}
