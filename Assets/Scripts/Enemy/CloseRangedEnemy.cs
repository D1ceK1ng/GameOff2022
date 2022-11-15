using UnityEngine;

public class CloseRangedEnemy : Enemy
{
    public override IMovable Movable { get => _movable; }
    public override Health Health => _health;
    public override float Speed { get => _speed; set => _speed = value; }
    public override float Damage { get => _damage; set => _damage = value; }
    public override Rigidbody2D Rigidbody { get => _rigidbody; set => _rigidbody = value; }

    private void OnEnable()
    {
        _movable = new DirectedEnemyMovement(transform, base.Target, Speed, _rigidbody);
    }
}
