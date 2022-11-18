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
    private Wall _wall;
    

    public WallUpgrade(List<Transform> spawnPoints, GameObject wallPrefab)
    {
        _spawnPoints = spawnPoints;
        _wallPrefab = wallPrefab;
        _wall = _wallPrefab.GetComponent<Wall>();
    }
    public override UpgradeType UpgradeType { get => _upgradeType; }

    public override bool GetCanUpgrade()
    {
        const int zeroScrapCount = 0;
        return (ScrapCounter.Instance.ScrapCount - _price) >= zeroScrapCount;
    }

    public override void Upgrade()
    {
        //if (GetCanUpgrade() == false) { return; }
        

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

    private void IncreaseUpgradeStats()
    {
        _price += _priceInflation;
        _currentUpgradeLevel++;

        if (_currentUpgradeLevel > _maxUpgradeLevel)
            _currentUpgradeLevel = _maxUpgradeLevel;
    }

    private void UpgradeWalls()
    {
        float healthIncrease = 3;
        var walls = Object.FindObjectsOfType<Wall>();
        foreach (var wall in walls)
        {
            Debug.Log(wall.WallHealth.CurrentHealth);
            wall.WallHealth.CurrentHealth += healthIncrease;
            
        }
    }

    private void BuildWalls()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            Object.Instantiate(_wallPrefab, _spawnPoints[i].position, _spawnPoints[i].rotation);
            Debug.Log("Lox");
        }
    }
}
