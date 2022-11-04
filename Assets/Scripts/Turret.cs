using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private List<Transform> _enemyList = new List<Transform>();
    [SerializeField] private float _speed = 200f;



    [SerializeField] private int _amountOfAmmo;
    [SerializeField] private float _startTimeBetweenShots;
    private float _timeBetweenShots;

    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shootPoint;




    //Idle animation
    //Shoot
    //Bullets track enemies?


    private void Start()
    {
        _timeBetweenShots = _startTimeBetweenShots;
    }


    private void Update()
    {
        if (_enemyList.Count > 0)
            RotateTowardsEnemy();

        if (_amountOfAmmo > 0 && _timeBetweenShots > 0)
            _timeBetweenShots -= Time.deltaTime;

        if (_enemyList.Count > 0 && _timeBetweenShots <= 0 && _amountOfAmmo > 0)
            Shoot();
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



    private void Shoot()
    {
        GameObject _spawnedBullet = Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
        _spawnedBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 30f, ForceMode2D.Impulse);
        _timeBetweenShots = _startTimeBetweenShots;
        _amountOfAmmo --;
    }

    //Raycast to see if Turret has line of sight
    //Wait to fire until aiming at it
    //Make bullets follow
    //Recoil
}
