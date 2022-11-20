using UnityEngine;

public class ScrapGenerator : MonoBehaviour
{
    private float _generatedScrap = 0.01f;
    

    private void Update()
    {
        GenerateScrapOverTime();
    }

    private void GenerateScrapOverTime()
    {
        ScrapCounter.Instance.IncreaseScrapCount(_generatedScrap);
    }
}
