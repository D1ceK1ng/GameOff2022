using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainBase : MonoBehaviour
{
    [SerializeField] private UpgradeType _upgradeType;
    private MainBaseHealth _mainBaseHealth;

    public  UnityEvent<UpgradeType> OnUpgradePerform;


    private void Awake()
    {
        _mainBaseHealth = new MainBaseHealth();
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UpgradeBase();
        }
    }
    public void UpgradeBase()
    {
        
        OnUpgradePerform?.Invoke(_upgradeType);
    }

}

