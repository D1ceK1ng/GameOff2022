using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class DirectedEnemyMovement : MonoBehaviour, IMovable
{
    public float Speed { get; set; }
    private Vector3 _target;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _enemyDirection;
    private Enemy _enemyScript;
    private bool _hasATarget = false;

    private void Awake()
    {
        _enemyScript = GetComponent<Enemy>();
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        InvokeRepeating("SetVariables", 0f, 0.5f);

    }

    public void Move()
    {
        if (!_hasATarget) return;

        CalculateMovementDirection();

        _rigidbody2D.AddForce(_enemyDirection * Speed);
    }
    private void SetVariables()
    {
        if (_enemyScript.Target != null) _target = _enemyScript.Target.position;
        else if (_enemyScript.WanderPosition != Vector3.zero) _target = _enemyScript.WanderPosition;
        else
        {
            _hasATarget = false;
            return;
        }


        Speed = _enemyScript.Speed;
        _hasATarget = true;
    }

    private void CalculateMovementDirection()
    {
        _enemyDirection = (_target - transform.position).normalized;
    }

}
