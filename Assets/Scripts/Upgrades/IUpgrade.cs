
public abstract class AbstractUpgrade
{
    public abstract UpgradeType UpgradeType { get;}

    public abstract bool GetCanUpgrade();
    public abstract void Upgrade();
}
