using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private WallsHealth _wallHealth;

    public WallsHealth WallHealth { get => _wallHealth; set => _wallHealth = value; }

    private void Awake()
    {

        _wallHealth = new WallsHealth();
    }
    private void Update()
    {
        Debug.Log(_wallHealth.CurrentHealth);

    }
}
