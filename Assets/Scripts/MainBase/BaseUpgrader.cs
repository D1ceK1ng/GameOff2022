using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseUpgrader : MonoBehaviour
{
    [SerializeField]private  List<Transform> _spawnPoints;
    [SerializeField] private GameObject _wallPrefab;
    private List<AbstractUpgrade> _upgradeList;
    


    private void Awake()
    {
        _upgradeList = new List<AbstractUpgrade>()
        {
            new WallUpgrade(_spawnPoints,_wallPrefab)
        };

    }

    

    public void Upgrade(UpgradeType upgradeType)
    {
        

        foreach (var upgrade in _upgradeList)
        {
            if (upgrade.UpgradeType == upgradeType) 
            {
                upgrade.Upgrade();
            }
        }
    }


}
