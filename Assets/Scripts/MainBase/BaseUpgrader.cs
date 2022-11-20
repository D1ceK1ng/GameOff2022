using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseUpgrader : MonoBehaviour
{
    [SerializeField] private  List<Transform> _wallSpawnPoints;
    [SerializeField] private List<Transform> _towerSpawnPoints;
    [SerializeField] private GameObject _towerPrefab;
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private GameObject _scrapGeneratorPrefab;
    private MainBase _mainBase;
    private List<AbstractUpgrade> _upgradeList;
    private UpgradeType _upgradeType;
    


    private void Awake()
    {
        _upgradeType = new UpgradeType();
        _mainBase = GetComponent<MainBase>();
        _upgradeList = new List<AbstractUpgrade>()
        {
            new WallUpgrade(_wallSpawnPoints,_wallPrefab),
            new TowerUpgrade(_towerPrefab, _towerSpawnPoints),
            new BaseUpgrade(_scrapGeneratorPrefab,_mainBase)
        };

    }

    

    public void Upgrade(int upgradeTypeIndex)
    {
        _upgradeType = (UpgradeType)upgradeTypeIndex;
        
        foreach (var upgrade in _upgradeList)
        {
            if (upgrade.UpgradeType == _upgradeType ) 
            {
                upgrade.Upgrade();
            }
        }
    }


}
