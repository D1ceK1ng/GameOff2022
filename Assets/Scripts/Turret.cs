using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private List<Transform> _enemyList = new List<Transform>();
    [SerializeField] private float _speed = 200f;




    //Idle animation
    //Find Tagret
    //Look at target
    //Shoot
    //Bullets track enemies?



    private void Update()
    {
        if (_enemyList.Count > 0)
            RotateTowardsEnemy();
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.TryGetComponent<Enemy>(out Enemy _enemy))
            _enemyList.Add(_enemy.transform);
        
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.TryGetComponent<Enemy>(out Enemy _enemy))
            _enemyList.Remove(_enemy.transform);
    }





    private void RotateTowardsEnemy()
    {
        Vector3 _target = _enemyList[0].position;
        _target.z = 0;

        _target.x -= transform.position.x;
        _target.y -= transform.position.y;

        float _angle = Mathf.Atan2(_target.y, _target.x) * Mathf.Rad2Deg;

        Quaternion _targetRotation = Quaternion.Euler(new Vector3(0, 0, _angle - 90f));

        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _speed * Time.deltaTime);
    }
}
