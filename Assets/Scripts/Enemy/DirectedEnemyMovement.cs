using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class DirectedEnemyMovement : IMovable
{
    public float Speed { get; set; }
    public Transform CurrentTransform { get; set; }
    private Transform _target;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _enemyDirection;

    public void Move()
    {
        CalculateMovementDirection();
        CurrentTransform.position = (Vector2)CurrentTransform.position + _enemyDirection * Speed * Time.deltaTime;
    }
    public DirectedEnemyMovement(Transform enemyPoint, Transform target, float speed,Rigidbody2D rigidbody2D)
    {
        CurrentTransform = enemyPoint;
        _target = target;
        Speed = speed;
        _rigidbody2D = rigidbody2D;
    }

    private void CalculateMovementDirection()
    {
        _enemyDirection = (_target.position - CurrentTransform.position).normalized;
    }

}
