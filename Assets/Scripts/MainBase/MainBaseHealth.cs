using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBaseHealth : Health
{
    
    private readonly float _maxBaseHealth = 10f;
    public override IDamageAccepting DamageAccepting { get; set; }
    
    private void OnEnable()
    {
        DamageAccepting = new SimpleDamageHandler();
        OnDestroy += EndGame;
    }

    private void EndGame(Health obj)
    {
        Debug.Log("Game Over");
    }

    public MainBaseHealth()
    {
        
        CurrentHealth = _maxBaseHealth;
        
    }
   
    public override void TryApplyingDamage(float damage)
    {
        ApplyDamage(damage);
    }

    private void OnDisable()
    {
        OnDestroy -= EndGame;
    }
}
