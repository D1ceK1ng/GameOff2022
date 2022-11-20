using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : AbstractUpgrade
{
    private const int _maxUpgradeLevel = 3;
    private const int _priceInflation = 4;
    private int _currentUpgradeLevel = 0;
    private int _price = 8;
    private readonly UpgradeType _upgradeType = UpgradeType.TowerUpgrade;
    private GameObject _towerPrefab;
    private List<Transform> _towerSpawnPoints;
    public override UpgradeType UpgradeType => _upgradeType;
   
    protected override int Price { get => _price; set => _price = value; }
    protected override int PriceInflation => _priceInflation;
    protected override int CurrentUpgradeLevel { get => _currentUpgradeLevel; set => _currentUpgradeLevel = value; }
    protected override int MaxUpgradeLevel => _maxUpgradeLevel;

    public TowerUpgrade(GameObject towerPrefab, List<Transform> towerSpawnPoints)
    {
        _towerPrefab = towerPrefab;
        _towerSpawnPoints = towerSpawnPoints;
    }
    public override void Upgrade()
    {
        if (GetCanUpgrade() == false) { return; }

        //Building walls or upgrading walls
        if (_currentUpgradeLevel == 0)
        {
            BuildTowers();
        }
        else if(_currentUpgradeLevel < _maxUpgradeLevel) 
        {
            UpgradeTowers();
        }
        IncreaseUpgradeStats();
    }

    

    private void UpgradeTowers()
    {
        Debug.Log("Upgradeing tower parametres ");
    }

    private void BuildTowers()
    {
        for (int i = 0; i < _towerSpawnPoints.Count; i++)
        {
            Object.Instantiate(_towerPrefab, _towerSpawnPoints[i].position, _towerSpawnPoints[i].rotation);
        }
    }
}
