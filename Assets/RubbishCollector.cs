using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishCollector : MonoBehaviour
{
    [SerializeField] private List<Rubbish> _currentRubbish;

    public event Action OnRubbishRecycled;
    public int CurrentRubbishValue { get; set; }

    private void Awake()
    {
        _currentRubbish = new List<Rubbish>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Rubbish rubbish))
        {
            _currentRubbish.Add(other.gameObject.GetComponent<Rubbish>());
            StartCoroutine(RubbishRecycling());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Rubbish rubbish))
        {
            _currentRubbish.Remove(other.gameObject.GetComponent<Rubbish>());
            StopCoroutine(RubbishRecycling());
        }
    }

    private IEnumerator RubbishRecycling()
    {
        
        var countdown = 3f;
        yield return new WaitForSeconds(countdown);

        for (int i = 0; i < _currentRubbish.Count; i++)
        {
            CurrentRubbishValue = _currentRubbish[i].ScrapValue;
            Destroy(_currentRubbish[i].gameObject);
            OnRubbishRecycled?.Invoke();
        }

        
    }
}
