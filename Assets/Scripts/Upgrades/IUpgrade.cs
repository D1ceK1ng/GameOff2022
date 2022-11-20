
using UnityEngine;

public abstract class AbstractUpgrade
{
    protected abstract int MaxUpgradeLevel { get; }
    public abstract UpgradeType UpgradeType { get;}
    protected abstract int PriceInflation { get; }
    protected abstract int CurrentUpgradeLevel { get; set; }
    protected abstract int Price{ get; set; }
    

    protected  bool GetCanUpgrade()
    {
        const int zeroScrapCount = 0;
        bool canUpgrade = (ScrapCounter.Instance.ScrapCount - Price) >= zeroScrapCount;
        if (canUpgrade)
            ScrapCounter.Instance.DecreaseScrapCount(Price);
        return canUpgrade;
    }

    protected void IncreaseUpgradeStats()
    {
        Price += PriceInflation;
        CurrentUpgradeLevel++;

        if (CurrentUpgradeLevel > MaxUpgradeLevel)
            CurrentUpgradeLevel = MaxUpgradeLevel;
    }

    public abstract void Upgrade();
}
