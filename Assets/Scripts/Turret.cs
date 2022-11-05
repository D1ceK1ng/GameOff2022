using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public bool CanShoot = true, CanRotate = true;
    private List<Transform> _enemyList = new List<Transform>();
    [SerializeField] private float _rotationSpeed = 200f, _bulletSpeed = 30f;



    [SerializeField] private int _amountOfAmmo;
    [SerializeField] private float _startTimeBetweenShots, _accuracyBeforeShooting;
    private float _timeBetweenShots;

    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shootPoint;
    private Quaternion _targetRotation;





    //Idle animation
    //Shoot
    //Bullets track enemies?


    private void Start()
    {
        _timeBetweenShots = _startTimeBetweenShots;
    }


    private void Update()
    {
        //If enemies, rotate
        if (_enemyList.Count > 0)
            RotateTowardsEnemy();

        //If ammo and time on timer
        if (_amountOfAmmo > 0 && _timeBetweenShots > 0)
            _timeBetweenShots -= Time.deltaTime;


        //If enemies, no Timer, Has Ammo, and is aiming at target
        if (_enemyList.Count > 0 &&
            _timeBetweenShots <= 0 &&
            _amountOfAmmo > 0 &&
            Quaternion.Angle(transform.rotation, _targetRotation) < _accuracyBeforeShooting)

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

        float _angle;

        if (InterceptionDirection(_enemyList[0].position, transform.position, _enemyList[0].GetComponent<Rigidbody2D>().velocity, _bulletSpeed, out var direction))
            _angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        else
            _angle = Mathf.Atan2(_target.y, _target.x) * Mathf.Rad2Deg;
        

        _targetRotation = Quaternion.Euler(new Vector3(0, 0, _angle - 90f));




        if (!CanRotate || !HasLineOfSight()) return;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
    }



    private void Shoot()
    {
        if (!CanShoot) return;

        GameObject _spawnedBullet = Instantiate(_bullet, _shootPoint.position, Quaternion.identity);

        _spawnedBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * _bulletSpeed, ForceMode2D.Impulse);
        _timeBetweenShots = _startTimeBetweenShots;
        _amountOfAmmo --;
    }


    private bool HasLineOfSight()
    {
        if (_enemyList.Count == 0) return false;

        //Debug.DrawRay(transform.position, _enemyList[0].transform.position - transform.position, Color.red);
        return Physics2D.Raycast(transform.position, (_enemyList[0].transform.position - transform.position).normalized).transform.TryGetComponent<Enemy>(out Enemy _enemyScript);
        //RaycastHit2D _hit = Physics2D.Raycast(transform.position, (_enemyList[0].transform.position - transform.position).normalized);
    }




    private bool InterceptionDirection(Vector2 a, Vector2 b, Vector2 vA, float sB, out Vector2 result)
    {
        var aToB = b - a;
        var dC = aToB.magnitude;
        var alpha = Vector2.Angle(aToB, vA) * Mathf.Deg2Rad;
        var sA = vA.magnitude;
        var r = sA / sB;

        if(SolveQuadratic(1 - r * r, 2 * r * dC * Mathf.Cos(alpha), -(dC * dC), out var root1, out var root2) == 0)
        {
            //No valid Solutions
            result = Vector2.zero;
            return false;
        }

        var dA = Mathf.Max(root1, root2);
        var t = dA / sB;
        var c = a + vA * t;
        result = (c - b).normalized;
        return true;
    }



    private static int SolveQuadratic(float a, float b, float c, out float root1, out float root2)
    {
        var discriminant = b * b - 4 * a * c;
        if(discriminant < 0)
        {
            root1 = Mathf.Infinity;
            root2 = -root1;
            return 0;
        }

        root1 = (-b + Mathf.Sqrt(discriminant)) / (2 * a);
        root2 = (-b - Mathf.Sqrt(discriminant)) / (2 * a);
       
        return discriminant > 0 ? 2 : 1;
    }
}