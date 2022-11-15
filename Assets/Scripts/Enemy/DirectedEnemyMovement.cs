using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class DirectedEnemyMovement : MonoBehaviour, IMovable
{
    public float Speed { get; set; }
    private Transform _target;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _enemyDirection;
    private Enemy _enemyScript;

    private void Start()
    {
        _enemyScript = GetComponent<Enemy>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        if (_target == null) return;

        SetVariables();
        CalculateMovementDirection();

        _rigidbody2D.AddForce(_enemyDirection * Speed);
    }
    private void SetVariables()
    {
        _target = _enemyScript.Target;

        Speed = _enemyScript.Speed;
    }

    private void CalculateMovementDirection()
    {
        _enemyDirection = (_target.position - transform.position).normalized;
    }

}
