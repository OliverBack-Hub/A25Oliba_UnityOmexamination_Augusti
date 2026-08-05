using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public HealthUI healthUI;

    private SpriteRenderer spriterenderer;

    public static event Action OnplayedDied;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthUI.SetMaxHearts(maxHealth);

        spriterenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyPatrol enemy = collision.GetComponent<enemyPatrol>();
        if (enemy)
        {
            TakeDamage(enemy.damage);
            SoundEffectManager.Play("Hit");
        }
        FloorIsLava lava = collision.GetComponent<FloorIsLava>();
        if (lava)
        {
            TakeDamage(lava.damage);
        }

    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthUI.UpdateHearts(currentHealth);

        StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            //player dead! --call game over, animation, etc
            SceneManager.LoadScene("GameOverScene");
           
        }
    }

    private IEnumerator FlashRed()
    {
        spriterenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriterenderer.color = Color.white;
    }
}
