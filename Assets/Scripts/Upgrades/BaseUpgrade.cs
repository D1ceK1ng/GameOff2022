using System;
using UnityEngine;

public class BaseUpgrade : AbstractUpgrade
{
    private const int _maxUpgradeLevel = 5;
    private const int _priceInflation = 6;
    private int _currentUpgradeLevel = 0;
    private int _price = 20;
    
    private readonly UpgradeType _upgradeType = global::UpgradeType.BaseUpgrade;

    public override UpgradeType UpgradeType => _upgradeType;

    public override bool GetCanUpgrade()
    {
        const int zeroScrapCount = 0;
        return (ScrapCounter.Instance.ScrapCount - _price) >= zeroScrapCount && _currentUpgradeLevel < _maxUpgradeLevel;
    }

    public override void Upgrade()
    {
        if (GetCanUpgrade() == false) { return; }

        UpgradeBase();
        BuildScrapGenerator();

        
    }

    private void UpgradeBase()
    {
        //can't think of another method to do lader upgrading system that can easyli expand
        int firstBaseUpgrade = 0;
        int secondBaseUpgrade = 2;
        if (_currentUpgradeLevel == firstBaseUpgrade)
        {
            Debug.Log("Upgrading base hp");
            IncreaseUpgradeStats();
        }
        else if(_currentUpgradeLevel == secondBaseUpgrade) 
        {
            Debug.Log("Increase base hp even more");
        }
    }

    private void IncreaseUpgradeStats()
    {
        _currentUpgradeLevel++;
        _price += _priceInflation;
    }

    private void BuildScrapGenerator()
    {
        int scrapGeneratorUpgradeLevel = 1;
        if(_currentUpgradeLevel == scrapGeneratorUpgradeLevel)
        {
            Debug.Log("Building scrap generator");
            IncreaseUpgradeStats();
        }
    }
}
