using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDamageHandler : IDamageAccepting
{
    public void TakeDamage(ref float health, float damage)
    {
        health -= damage;
    }
}
