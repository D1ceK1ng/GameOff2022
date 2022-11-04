using UnityEngine;

public class RubbishPile : MonoBehaviour
{
    [SerializeField] private GameObject _scrapPrefab;
    [SerializeField] private int _spawnAmount;
    private float _countdown = 3f;
    private bool _canDigUp;
    

    private void Update()
    {
        if (_canDigUp)
        {
            StartCountdown();
        }
    }

    private void StartCountdown()
    {
        if (Input.GetKey(KeyCode.E) == false)
        {
            return;
        }

        if (_countdown <= 0)
        {
            SpawnScrap(_spawnAmount);
            Destroy(gameObject);
            _countdown = 3f;
        }

        _countdown -= Time.deltaTime;
    }

    private void SpawnScrap(int spawnAmount)
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            float minOffsetRange = 1f;
            float maxOffsetRange = 5f;
            Vector3 spawnOffset = new Vector3(Random.Range(minOffsetRange, maxOffsetRange), Random.Range(minOffsetRange, maxOffsetRange));
            
            Instantiate(_scrapPrefab, transform.position + spawnOffset, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        _canDigUp = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        _canDigUp = false;
    }
}
