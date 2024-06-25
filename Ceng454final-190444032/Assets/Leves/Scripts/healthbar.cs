using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthControl : MonoBehaviour
{
    public int Respawn;
    private float _maxHealth = 100;
    private float _currentHealth;
    [SerializeField] private Image _healthBarFill;
    [SerializeField] private float _damageAmount;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        // Add health bar updates or other controls here if needed.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("die"))
        {
            TakeDamage(_damageAmount);
        }
        if (collision.CompareTag("sawk"))
        {
            TakeDamage(50);
        }if (collision.CompareTag("saw"))
        {
            TakeDamage(100);
        }
        if (collision.CompareTag("fire"))
        {
            TakeDamage(100);
        }
        if (collision.CompareTag("spikes"))
        {
            TakeDamage(2);
        }
        if (collision.CompareTag("spikehead"))
        {
            TakeDamage(70);
        }
        if (collision.CompareTag("Player"))
        {
            Die();
        }
        if (collision.CompareTag("skiped"))
        {
            TakeDamage(10);
        }
    }

    private void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        if (_currentHealth == 0)
        {
            Die();
        }
        UpdateHealthBar();
    }

    private void Die()
    {
        // Reset the coin score to zero
        CoinScore.coinAmount = 0;

        // Reload the scene to respawn
        SceneManager.LoadScene(Respawn);
    }

    private void UpdateHealthBar()
    {
        _healthBarFill.fillAmount = _currentHealth / _maxHealth;
    }
}