using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Health stats")]
    [SerializeField] private float _maxHealth = 100;
    private float _currentHealth;
    [SerializeField] private Gradient _gradient;

    public event Action<float> HealthChanged;
    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {

    }

    public void ChangeHealth(float value)
    {
        _currentHealth += value;

        if (_currentHealth <= 0)
        {
            Death();
        }
        else
        {
            //HealthChanged?.Invoke((float)_currentHealth / _maxHealth);
            GameObject hpBar = null;
            if (this.gameObject.tag == "Player")
            {
                hpBar = GameObject.Find("HPBar");
            }
            else
            {
                hpBar = GameObject.Find("HPBarObject");
            }

            Debug.Log((float)_currentHealth / _maxHealth);
            hpBar.GetComponent<Image>().fillAmount = (float)_currentHealth / _maxHealth;
            hpBar.GetComponent<Image>().color = _gradient.Evaluate((float)_currentHealth / _maxHealth);
            hpBar.GetComponent<Image>().color = _gradient.Evaluate((float)_currentHealth / _maxHealth);
        }
    }

    private void Death()
    {
        //HealthChanged?.Invoke(0);
        var hpBar = GameObject.Find("HPBarObject");
        Debug.Log(0);
        hpBar.GetComponent<Image>().fillAmount = 0;
        hpBar.GetComponent<Image>().color = _gradient.Evaluate(0);
        hpBar.GetComponent<Image>().color = _gradient.Evaluate(0);
        Destroy(gameObject);
        Debug.Log(gameObject.name + " ARE DEAD");
    }
}
