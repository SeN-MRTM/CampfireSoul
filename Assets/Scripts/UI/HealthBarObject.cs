using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Microsoft.Unity.VisualStudio.Editor;
public class HealthBarObject : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image _healthBarFilling;

    [SerializeField] public Health _health;

    [SerializeField] private Gradient _gradient;

    private void Start()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    public void OnHealthChanged(float valueAsPercantage)
    {
        Debug.Log(valueAsPercantage);
        _healthBarFilling.fillAmount = valueAsPercantage;
        _healthBarFilling.color = _gradient.Evaluate(valueAsPercantage);
        _healthBarFilling.color = _gradient.Evaluate(valueAsPercantage);
    }
}
