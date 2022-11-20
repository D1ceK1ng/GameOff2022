using System.Collections.Generic;
using UnityEngine;

public class WallUpgrade : AbstractUpgrade
{
    private const int _maxUpgradeLevel = 3;
    private const int _priceInflation = 5;
    private int _price = 10;
    private int _currentUpgradeLevel = 0;
    private readonly UpgradeType _upgradeType = UpgradeType.WallUpgrade;
    private GameObject _wallPrefab;
    private List<Transform> _spawnPoints;

    protected override int Price { get => _price; set => _price = value; }
    public override UpgradeType UpgradeType => _upgradeType;

    protected override int PriceInflation => _priceInflation;

    protected override int CurrentUpgradeLevel { get => _currentUpgradeLevel; set => _currentUpgradeLevel = value; }

    protected override int MaxUpgradeLevel => _maxUpgradeLevel;

    public WallUpgrade(List<Transform> spawnPoints, GameObject wallPrefab)
    {
        _spawnPoints = spawnPoints;
        _wallPrefab = wallPrefab;
    }
    
    public override void Upgrade()
    {
        if (GetCanUpgrade() == false) { return; }
        

        //Building walls or upgrading walls
        if (_currentUpgradeLevel == 0)
        {
            BuildWalls();
        }
        else if(_currentUpgradeLevel < _maxUpgradeLevel) 
        {
            UpgradeWalls();
        }
        IncreaseUpgradeStats();
    }

    

    private void UpgradeWalls()
    {
        float healthIncrease = 3;
        var walls = Object.FindObjectsOfType<Wall>();
        foreach (var wall in walls)
        {
            wall.WallHealth.CurrentHealth += healthIncrease;
            
        }
    }

    private void BuildWalls()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            Object.Instantiate(_wallPrefab, _spawnPoints[i].position, _spawnPoints[i].rotation);
        }
    }
}
