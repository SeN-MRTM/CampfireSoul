using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour
{
    [Header("Health stats")]
    [SerializeField] private int _maxHealth = 100;
    private int _currentHealth;

    public event Action<float> HealthChanged;
    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeHealth(-10);
        }
    }
    
    public void ChangeHealth(int value)
    {
        _currentHealth += value;

        if(_currentHealth <= 0)
        {
            Death();
        }
        else
        {
            HealthChanged?.Invoke((float)_currentHealth / _maxHealth);
        }
    }

    private void Death()
    {
        HealthChanged?.Invoke(0);
        Debug.Log("YOU ARE DEAD");
    }
}
