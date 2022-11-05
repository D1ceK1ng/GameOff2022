using System.Collections;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private float _coolDownTime = 1;
    public override IDamageAccepting DamageAccepting { get; set; }
    private bool _isReloaded = true;

    private void OnEnable()
    {
        DamageAccepting = new SimpleDamageHandler();
    }
    private void Start()
    {
        OnDestroy += DestroyPlayer;
    }
    private void DestroyPlayer(Health health)
    {
        Destroy(health.gameObject);
    }
    public override void TryApplyingDamage(float damage)
    {
        if (_isReloaded)
        {
            ApplyDamage(damage);
            StartCoroutine(CoolDown());
        }
    }
    private IEnumerator CoolDown()
    {
        _isReloaded = false;
        yield return new WaitForSeconds(_coolDownTime);
        _isReloaded = true;
    }
    private void OnDisable()
    {
        OnDestroy -= DestroyPlayer;
    }

}
