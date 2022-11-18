using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapCounter : MonoBehaviour
{

    private RubbishCollector _rubbishCollector;
    private int _scrapCount = 0;
    public int ScrapCount { get => _scrapCount; set => _scrapCount = value; }

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

    private void IncreaseScrapCount(int value)
    {
        ScrapCount += value;
       
        Debug.Log(ScrapCount);
    }



    private void OnDisable()
    {
        _rubbishCollector.OnRubbishRecycled -= () => IncreaseScrapCount(_rubbishCollector.CurrentRubbishValue);
    }


}
