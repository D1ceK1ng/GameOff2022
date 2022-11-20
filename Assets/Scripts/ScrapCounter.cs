using UnityEngine;

public class ScrapCounter : MonoBehaviour
{

    private RubbishCollector _rubbishCollector;
    private float _scrapCount = 0;
    public float ScrapCount { get => _scrapCount; set => _scrapCount = value; }

    public static ScrapCounter Instance { get; private set; } = null;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _rubbishCollector = FindObjectOfType<RubbishCollector>();


        _rubbishCollector.OnRubbishRecycled += () => IncreaseScrapCount(_rubbishCollector.CurrentRubbishValue);
    }

    public void IncreaseScrapCount(float value)
    {
        ScrapCount += value;

        Debug.Log(ScrapCount);
    }
    public void DecreaseScrapCount(float value)
    {
        ScrapCount -= value;
    }



    private void OnDisable()
    {
        _rubbishCollector.OnRubbishRecycled -= () => IncreaseScrapCount(_rubbishCollector.CurrentRubbishValue);
    }


}
