using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWander : MonoBehaviour
{
    [SerializeField] private float _wonderDistance = 5f, _strengthTowardsRocket = 2f, _timeBetweenTicks = 4f;
    private Enemy _enemyScript;

    private Vector3 _rocketPosition;
    void Start()
    {
        _enemyScript = GetComponent<Enemy>();

        _rocketPosition = Rocket.RocketScript.transform.position;

        InvokeRepeating("SetTarget", 0, _timeBetweenTicks);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetTarget()
    {
        if(_enemyScript.Target == null)
        {
            //_enemyScript.Target = //Its a transform but this is a Vector3
        }
    }

    private Vector3 GetRandomPoint()
    {
        Vector2 rocketDirection = (_rocketPosition - transform.position).normalized;

        //Creates a circle that moves x units towards Rocket so Enemies slowly move towards it
        return (rocketDirection * _strengthTowardsRocket) + (Random.insideUnitCircle * _wonderDistance);
    }
}
