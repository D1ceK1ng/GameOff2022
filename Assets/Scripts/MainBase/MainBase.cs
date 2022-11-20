using UnityEngine;
using UnityEngine.Events;

public class MainBase : MonoBehaviour
{
 
    private MainBaseHealth _mainBaseHealth;

    public  UnityEvent OnUpgradePerform;

    public MainBaseHealth MainBaseHealth { get => _mainBaseHealth; set => _mainBaseHealth = value; }

    private void Awake()
    {
        _mainBaseHealth = new MainBaseHealth();
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UpgradeBase();
        }
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            ScrapCounter.Instance.ScrapCount += 10;
        }
    }
    public void UpgradeBase()
    {
        
        OnUpgradePerform?.Invoke();
    }

}

