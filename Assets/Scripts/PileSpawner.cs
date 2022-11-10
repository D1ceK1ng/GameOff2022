using UnityEngine;

public class PileSpawner : MonoBehaviour
{
    private GameObject _scrapPrefab;
    private Transform _spawningTransform;

    public PileSpawner(GameObject scrapPrefab, Transform spawningTransform)
    {
        _scrapPrefab = scrapPrefab;
        _spawningTransform = spawningTransform;
    }

    public void SpawnFromPile(int spawnAmount)
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            var spawnOffset = CalculateSpawnOffset();

            Instantiate(_scrapPrefab, _spawningTransform.position + spawnOffset, _spawningTransform.rotation);
        }
    }

    private static Vector3 CalculateSpawnOffset()
    {
        const float spawnRadius = 4f;
        float spawnAngle = Random.Range(0, Mathf.PI * 2);    // Random angle in radians


        Vector3 spawnOffset = new Vector2(Mathf.Sin(spawnAngle) * spawnRadius, Mathf.Cos(spawnAngle) * spawnRadius);
            
        return spawnOffset;
    }
}
