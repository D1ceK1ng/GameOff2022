using UnityEngine;

public class RubbishPile : MonoBehaviour
{
    [SerializeField] private GameObject _scrapPrefab;
    [SerializeField] private int _spawnAmount;
    private float _countdown = 3f;
    private bool _canDigUp;
    private PileSpawner _spawner;

    private void Awake()
    {
        _spawner = new PileSpawner(_scrapPrefab,transform);
    }
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
            _spawner.SpawnFromPile(_spawnAmount);
            Destroy(gameObject);    
            _countdown = 3f;
        }

        _countdown -= Time.deltaTime;
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
