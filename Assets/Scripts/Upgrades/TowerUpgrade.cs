using UnityEngine;

public class TowerUpgrade : AbstractUpgrade
{
    private const int _maxUpgradeLevel = 3;
    private const int _priceInflation = 4;
    private int _currentUpgradeLevel = 0;
    private int _price = 8;

    private readonly UpgradeType _upgradeType = UpgradeType.TowerUpgrade;

    public override UpgradeType UpgradeType => _upgradeType;
    public override bool GetCanUpgrade()
    {

        const int zeroScrapCount = 0;
        return (ScrapCounter.Instance.ScrapCount - _price) >= zeroScrapCount && _currentUpgradeLevel < _maxUpgradeLevel;
    }

    public override void Upgrade()
    {
        if (GetCanUpgrade() == false) { return; }

        //Building walls or upgrading walls
        if (_currentUpgradeLevel == 0)
        {
            BuildTowers();
        }
        else
        {
            UpgradeTowers();
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

    private void UpgradeTowers()
    {
        Debug.Log("Upgradeing towers hp and texture ");
    }

    private void BuildTowers()
    {
        Debug.Log("Building Towers");
    }
}
