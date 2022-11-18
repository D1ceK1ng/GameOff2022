using UnityEngine;

public class WallsHealth : Health
{
    private readonly float _maxWallHealth = 3f;
    public override IDamageAccepting DamageAccepting { get; set ; }

    

    private void Awake()
    {
        DamageAccepting = new SimpleDamageHandler();
     
    }

    public WallsHealth()
    {
        CurrentHealth = _maxWallHealth;
    }

    public override void TryApplyingDamage(float damage)
    {
        ApplyDamage(damage);
    }
}
