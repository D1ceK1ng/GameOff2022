using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private float _currentHealth = 5;
    private float _maxHealth;

    public event Action OnChangeHealth;
    public event Action<Health> OnDestroy;
    public event Action OnSetMaxHealth;
    public abstract IDamageAccepting DamageAccepting { get; set; }
    public float CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = value;
    }
    public float MaxHealth
    {
        get => _maxHealth;
        set => _maxHealth = value;
    }

    private void Awake()
    {
        _maxHealth = CurrentHealth;
        OnSetMaxHealth?.Invoke();
    }

    public abstract void TryApplyingDamage(float damage);

    private protected void ApplyDamage(float damage)
    {
        DamageAccepting.TakeDamage(ref _currentHealth, damage);
        OnChangeHealth?.Invoke();
        if (CurrentHealth <= 0)
        {
            OnDestroy?.Invoke(this);
        }
    }
}