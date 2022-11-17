using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private Enemy _enemyScript;
    private List<Transform> _targetList = new List<Transform>();

    private void Awake()
    {
        _enemyScript = GetComponent<Enemy>();
    }

    private void Start()
    {
        InvokeRepeating("HasLineOfSight", 0f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(_enemyScript.Target == null && IsATarget(col.transform))
        {
            _targetList.Add(col.transform);
        }
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if (_enemyScript.Target == null && IsATarget(col.transform))
        {
            _targetList.Remove(col.transform);
        }
    }


    private void HasLineOfSight()
    {
        if (_enemyScript.Target != null) return;


        foreach(Transform target in _targetList)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, (target.position - transform.position).normalized, 10f);

            if (IsATarget(hit.transform))
            {
                Debug.Log(hit.transform.name);
                _enemyScript.Target = target;
                return;
            }
        }
    }


    private bool IsATarget(Transform target)
    {
        if (_enemyScript.Priority == Enemy.PriorityList.Player && target.TryGetComponent<Player>(out _) ||
              _enemyScript.Priority == Enemy.PriorityList.Rocket && target.TryGetComponent<Rocket>(out _) ||
              _enemyScript.Priority == Enemy.PriorityList.Turret && target.TryGetComponent<Turret>(out _))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
