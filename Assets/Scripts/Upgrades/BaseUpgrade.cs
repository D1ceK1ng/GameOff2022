using UnityEngine;

public class BaseUpgrade : AbstractUpgrade
{
    private const int _maxUpgradeLevel = 5;
    private const int _priceInflation = 6;
    private int _currentUpgradeLevel = 0;
    private int _price = 20;
    private readonly UpgradeType _upgradeType = UpgradeType.BaseUpgrade;
    private MainBase _mainBase;
    private GameObject _scrapGeneratorPrefab;

    public override UpgradeType UpgradeType => _upgradeType;

    protected override int Price { get => _price; set => _price = value; }


    protected override int PriceInflation => _priceInflation;

    protected override int CurrentUpgradeLevel { get => _currentUpgradeLevel; set => _currentUpgradeLevel = value; }

    protected override int MaxUpgradeLevel => _maxUpgradeLevel;


    public BaseUpgrade(GameObject scrapGeneratorPrefab, MainBase mainBase)
    {
        _scrapGeneratorPrefab = scrapGeneratorPrefab;
        _mainBase = mainBase;
    }
    public override void Upgrade()
    {
        if (GetCanUpgrade() == false) { return; }

        UpgradeBase();
        BuildScrapGenerator();
        IncreaseUpgradeStats();
        
    }

    private void UpgradeBase()
    {
        //can't think of another method to do lader upgrading system that can easyli expand
        int scrapGeneratorUpgrade = 0;
        int incresedHealthAmount = 5;
        if (_currentUpgradeLevel != scrapGeneratorUpgrade)
        {
            _mainBase.MainBaseHealth.IncreaseHealth(incresedHealthAmount);
            
        }
        
       
    }

    

    private void BuildScrapGenerator()
    {
        int scrapGeneratorUpgradeLevel = 1;
        if(_currentUpgradeLevel == scrapGeneratorUpgradeLevel)
        {
            Object.Instantiate(_scrapGeneratorPrefab,new Vector3(_mainBase.transform.position.x + 5, _mainBase.transform.position.y - 4 ),_mainBase.transform.rotation);

        }
    }
}
